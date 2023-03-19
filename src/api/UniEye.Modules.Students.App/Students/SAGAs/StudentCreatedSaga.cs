using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Modules.Students.Shared.Events;
using UniEye.Modules.Users.Shared.Commands;

namespace UniEye.Modules.Students.App.Students.SAGAs
{
    public class StudentCreatedSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int CurrentState { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentCreatedSaga : MassTransitStateMachine<StudentCreatedSagaState>
    {
        public StudentCreatedSaga()
        {
            InstanceState(x => x.CurrentState);
            Event(() => StudentCreated);

            Initially(
                When(StudentCreated)
                    .Then(x => x.Saga.FirstName = x.Message.FirstName)
                    .Then(x => x.Saga.LastName = x.Message.LastName)
                    .Publish(context => new CreateUserIntegrationCommand(context.Saga.FirstName, context.Saga.LastName, context.Saga.CorrelationId))
                    .Finalize());
        }

        public Event<StudentCreatedEvent> StudentCreated { get; private set; }
    }
}
