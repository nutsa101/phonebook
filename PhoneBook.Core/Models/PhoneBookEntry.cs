using System;

namespace PhoneBook.Core.Models
{
    public class PhoneBookEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
