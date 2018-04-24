using System.Diagnostics;
using Prism.Logging;

namespace FarmLabDevice.Services
{
    public class DebugLogger : ILoggerFacade
    {
        public void Log(string message, Category category, Priority priority)
        {
            Debug.WriteLine($"{category} - {priority}: {message}");
        }
    }
}
