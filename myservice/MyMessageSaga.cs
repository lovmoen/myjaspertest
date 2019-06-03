using Jasper.Messaging.Runtime.Invocation;
using Jasper.Messaging.Sagas;
using System;
using System.Collections.Generic;
using System.Text;

namespace myservice
{
    public class MyMessageSaga : StatefulSagaOf<MyMessageState>
    {
        public (MyMessageState, object[]) Starts(MyMessage message)
        {
            var state = new MyMessageState
            {
                Id = message.Id,
                Message = message
            };

            return (state, GetResponses(message));
        }

        private object[] GetResponses(MyMessage message)
        {
            var response = Respond.With(new MyResponse { Id = Guid.NewGuid(), Response = $"Response to {message.Message}" }).ToSender();
            return new object[] { response };
        }
    }
}
