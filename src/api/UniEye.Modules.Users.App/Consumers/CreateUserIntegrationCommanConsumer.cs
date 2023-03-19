﻿using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using UniEye.Modules.Users.App.Settings;
using UniEye.Modules.Users.Shared.Commands;

namespace UniEye.Modules.Users.App.Consumers
{
    public class CreateUserIntegrationCommanConsumer : IConsumer<CreateUserIntegrationCommand>
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly AzureAdOptions _azureAdOptions;

        public CreateUserIntegrationCommanConsumer(GraphServiceClient graphServiceClient, IOptions<AzureAdOptions> azureAdOptions)
        {
            _graphServiceClient = graphServiceClient;
            _azureAdOptions = azureAdOptions.Value;
        }

        public async Task Consume(ConsumeContext<CreateUserIntegrationCommand> context)
        {
            var message = context.Message;
            await CreateAdUser(message);
        }

        private async Task CreateAdUser(CreateUserIntegrationCommand message)
        {
            var principalName = await GetEmail(message.FirstName, message.LastName);
            var newUser = new User
            {
                Id = message.Id.ToString(),
                AccountEnabled = true,
                DisplayName = $"{message.FirstName} {message.LastName}",
                Mail = message.Email,
                MailNickname = $"{message.FirstName}.{message.LastName}",
                GivenName = message.FirstName,
                Surname = message.LastName,
                UserPrincipalName = principalName,
                PasswordProfile = new PasswordProfile
                {
                    Password = "Pa$$word",
                    ForceChangePasswordNextSignIn = true
                }
            };

            await _graphServiceClient.Users.Request().AddAsync(newUser);
        }

        private async Task<string> GetEmail(string firstName, string lastName)
        {
            for (int? i = null; ; i = i.HasValue ? i + 1 : 1)
            {
                var userPrincipalName = $"{firstName}.{lastName}{i}@{_azureAdOptions.Domain}";

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
