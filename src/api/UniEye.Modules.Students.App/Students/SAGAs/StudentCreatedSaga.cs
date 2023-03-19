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
        public string? DisplayName { get; set; }
        public string? DomainName { get; set; }
        public string? FirstLoginPassword { get; set; }
    }

    public class StudentCreatedSaga : MassTransitStateMachine<StudentCreatedSagaState>
    {
        public StudentCreatedSaga()
        {
            InstanceState(x => x.CurrentState, StudentExistsState);
            Event(() => StudentCreated);

            Initially(
                When(StudentCreated)
                    .Then(x => {
                        x.Saga.FirstName = x.Message.FirstName;
                        x.Saga.LastName = x.Message.LastName;
                    })
                    .Publish(context => new CreateUserIntegrationCommand(context.Saga.FirstName, context.Saga.LastName, context.Saga.CorrelationId))
                    .TransitionTo(StudentExistsState));

            During(StudentExistsState,
                When(UserCreated)
                    .Then(x => { 
                        x.Saga.PersonalEmail = x.Message.PersonalEmail;
                        x.Saga.DisplayName = x.Message.DisplayName;
                        x.Saga.DomainName = x.Message.DomainName;
                        x.Saga.FirstLoginPassword = x.Message.FirstLoginPassword;
                    })
                    .Publish(context => new SendNotificationIntegrationCommand(
                        NotificationTemplateProvider.UserOnboardingTemplate(context.Saga.PersonalEmail, context.Saga.DisplayName, context.Saga.DomainName, context.Saga.FirstLoginPassword)
                    ))
                    .Finalize());
                
        }

        public State StudentExistsState { get; private set; }


        public Event<StudentCreatedEvent> StudentCreated { get; private set; }
        public Event<UserCreatedEvent> UserCreated { get; private set; }
    }
}
