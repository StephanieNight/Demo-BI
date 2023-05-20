using Models;

namespace Domain.Models
{
    public class UniqueWordsEntity : BaseEntity<Guid>
    {
        public int Count { get; set; }
    }
}