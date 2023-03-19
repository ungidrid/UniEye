using MassTransit;
using UniEye.Modules.Notifications.Shared.Commands;
using UniEye.Modules.Notifications.Shared.Templates;
using UniEye.Modules.Students.Shared.Events;
using UniEye.Modules.Users.Shared.Commands;
using UniEye.Modules.Users.Shared.Events;

namespace UniEye.Modules.Students.App.Students.SAGAs
{
    public class StudentCreatedSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int CurrentState { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalEmail { get; set; }
        public Guid Identity { get; set; }

        public string? DisplayName { get; set; }
        public string? DomainName { get; set; }
        public string? FirstLoginPassword { get; set; }

        public CreateUserIntegrationCommand CreateUserIntegrationCommand()
        {
            return new CreateUserIntegrationCommand(FirstName, LastName, PersonalEmail, Identity, CorrelationId);
        }

        public SendNotificationIntegrationCommand CreateSendOnboardingNotificationCommand()
        {
            var template = NotificationTemplateProvider.UserOnboardingTemplate(PersonalEmail, DisplayName, DomainName, FirstLoginPassword);
            return new SendNotificationIntegrationCommand(template, Identity);
        }

        public void PatchState(StudentCreatedEvent @event)
        {
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            PersonalEmail = @event.PersonalEmail;
            Identity = @event.Identity;
        }

        public void PatchState(UserCreatedEvent @event)
        {
            DisplayName = @event.DisplayName;
            DomainName = @event.DomainName;
            FirstLoginPassword = @event.FirstLoginPassword;
        }
    }

    public class StudentCreatedSaga : MassTransitStateMachine<StudentCreatedSagaState>
    {
        public StudentCreatedSaga()
        {
            InstanceState(x => x.CurrentState, StudentExistsState);
            Event(() => StudentCreated);

            Initially(
                When(StudentCreated)
                    .Then(x => x.Saga.PatchState(x.Message))
                    .Publish(context => context.Saga.CreateUserIntegrationCommand())
                    .TransitionTo(StudentExistsState));

            During(StudentExistsState,
                When(UserCreated)
                    .Then(x => x.Saga.PatchState(x.Message))
                    .Publish(context => context.Saga.CreateSendOnboardingNotificationCommand())
                    .Finalize());
                
        }

        public State StudentExistsState { get; private set; }


        public Event<StudentCreatedEvent> StudentCreated { get; private set; }
        public Event<UserCreatedEvent> UserCreated { get; private set; }
    }
}
