using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using UniEye.Modules.Users.App.Settings;
using UniEye.Modules.Users.Shared.Commands;
using UniEye.Modules.Users.Shared.Events;

namespace UniEye.Modules.Users.App.Consumers
{
    public class CreateUserIntegrationCommandConsumer : IConsumer<CreateUserIntegrationCommand>
    {
        private const string FIRST_LOGIN_PASSWORD = "Pa$$word";

        private readonly GraphServiceClient _graphServiceClient;
        private readonly IBus _bus;
        private readonly AzureAdOptions _azureAdOptions;

        public CreateUserIntegrationCommandConsumer(
            GraphServiceClient graphServiceClient, 
            IBus bus, 
            IOptions<AzureAdOptions> azureAdOptions)
        {
            _graphServiceClient = graphServiceClient;
            _bus = bus;
            _azureAdOptions = azureAdOptions.Value;
        }

        public async Task Consume(ConsumeContext<CreateUserIntegrationCommand> context)
        {
            var message = context.Message;
            var user = await CreateAdUser(message);

            var @event = new UserCreatedEvent(user.DisplayName, user.UserPrincipalName, FIRST_LOGIN_PASSWORD, message.Identity, context.CorrelationId);
            await _bus.Publish(@event);
        }

        private async Task<User> CreateAdUser(CreateUserIntegrationCommand message)
        {
            var principalName = await GetEmail(message.FirstName, message.LastName);

            var newUser = new User
            {
                Id = message.Identity.ToString(),
                AccountEnabled = true,
                DisplayName = $"{message.FirstName} {message.LastName}",
                Mail = message.PersonalEmail,
                MailNickname = $"{message.FirstName}.{message.LastName}",
                GivenName = message.FirstName,
                Surname = message.LastName,
                UserPrincipalName = principalName,
                PasswordProfile = new PasswordProfile
                {
                    Password = FIRST_LOGIN_PASSWORD,
                    ForceChangePasswordNextSignIn = true
                }
            };

            return await _graphServiceClient.Users.Request().AddAsync(newUser);
        }

        private async Task<string> GetEmail(string firstName, string lastName)
        {
            for (int? i = null; ; i = i.HasValue ? i + 1 : 1)
            {
                var userPrincipalName = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@{_azureAdOptions.Domain}";

                var users = await _graphServiceClient.Users
                    .Request()
                    .Filter($"userPrincipalName eq '{userPrincipalName}'")
                    .GetAsync();

                if (users.Any())
                {
                    continue;
                }

                return userPrincipalName;
            }
        }
    }
}
