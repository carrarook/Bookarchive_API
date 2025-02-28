using Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BaseEntity : Validatable
    {
        [Key]
        public Guid ID { get; set; }
        public DateTimeOffset Created { get; private set; }
        public DateTimeOffset? Update { get; private set; }
        public BaseEntity()
        {
            Created = DateTime.UtcNow;
            Update = null; 
        }

        public void setCreated(DateTimeOffset Created) { this.Created = Created; }
        public void setUpdate(DateTimeOffset Update) {  this.Update = Update; }


    }
}