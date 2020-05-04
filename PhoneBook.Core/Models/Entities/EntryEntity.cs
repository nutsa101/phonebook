using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Core.Models.Entities
{
    [Table("Entry")]
    public class EntryEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("PhoneBookId")]
        public Guid PhoneBookId { get; set; }
        public PhoneBookEntity PhoneBook { get; set; }
    }
}
