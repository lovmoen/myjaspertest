using myservice;
using System;
using System.Threading;

namespace mysender
{
    public class MyResponseHandler
    {
        public static ManualResetEvent MyResponseEvent = new ManualResetEvent(false);

        public void Handle(MyResponse response)
        {
            Console.WriteLine($"Handling MyResponse: {response.Id} {response.Response}");
            MyResponseEvent.Set();
        }
    }
}
