using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class BaseEntity<T>
    {
        // should make sequential https://stackoverflow.com/questions/47483679/entity-framework-uses-newsequentialid-for-guid-key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
    }
}
