using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Core.Models.Entities
{
    [Table("PhoneBook")]
    public class PhoneBookEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public ICollection<EntryEntity> Entries { get; set; }
    }
}
