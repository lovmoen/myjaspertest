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

            return (state, new object[0]);
        }
    }
}
