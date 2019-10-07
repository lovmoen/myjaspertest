using System;
using System.Threading.Tasks;
using Jasper;

namespace myservice
{
    internal class Program
    {
        static Task<int> Main(string[] args)
        {
            // The application is configured through the MyApp clas
            return JasperHost.Run<JasperConfig>(args);
        }
    }
}
