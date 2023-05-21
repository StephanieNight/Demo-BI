namespace DataService.Interfaces
{
    public interface ILoggingService
    {
        public void Log(string service, int dataSize, long elapsedTimeMs);
    }
}
