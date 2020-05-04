using System.Collections.Generic;

namespace PhoneBook.Core.Models.DTOs
{
    public class SearchPhoneBookResponse
    {
        public IEnumerable<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}
