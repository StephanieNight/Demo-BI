using DataAccess;
using DataService.Handlers.UniqueWords;

namespace DataService.Services
{
    public class ParallelBIService : BaseService
    {
        public ParallelBIService(BIContext context) : base(context, new ParallelHandler()) { }
    }
}