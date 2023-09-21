using System;

namespace H1_RestfulApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[ConsoleLogger] - {message}");
        }
    }
}
