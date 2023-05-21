using DataAccess;
using DataService.Interfaces;
using Models;

namespace DataService.Services
{
    public class LoggingService : ILoggingService
    {
        public readonly BIContext _context;

        public LoggingService(BIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Log(string service, int dataSize,long elapsedTimeMs)
        {
            var logEntity = new LogEntity()
            {
                ServiceName = service,
                DataSize = dataSize,    
                ElapsedTimeMs = elapsedTimeMs,
            };
            _context.Logs.Add(logEntity);
            _context.SaveChanges();
        }
    }
}
