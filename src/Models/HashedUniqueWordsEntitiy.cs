using Domain.Models;

namespace Models
{
    public class HashedUniqueWordsEntitiy : BaseEntity<Guid>
    {
        public int Count { get; set; }
        public int Hash { get; set; }
        public string Words { get; set; }
    }
}
