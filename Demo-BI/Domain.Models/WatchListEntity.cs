using System.ComponentModel.DataAnnotations;

namespace Models
{
    public  class WatchListEntity : BaseEntity<Guid>
    {
        [MaxLength(50)]
        public string Word { get; set; }
    }
}
