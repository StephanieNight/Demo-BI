using DataAccess;
using DataService.Handlers.UniqueWords;

namespace DataService.Services
{
    public class ParagraphBIService : BaseService
    {
        public ParagraphBIService(BIContext context) : base(context, new ParagraphHandler()) { }
    }
}