using DataAccess;
using DataService.Handlers.UniqueWords;



namespace DataService.Services
{
    public class DefaultBIService : BaseService
    {
        public DefaultBIService(BIContext context) : base(context, new SequentialHandler()) { }
    }
}