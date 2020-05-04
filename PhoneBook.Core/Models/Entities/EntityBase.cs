using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Models.Entities
{
    public class EntityBase
    {
        protected EntityBase()
        {
            CreatedOn = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
