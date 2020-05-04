using System;
using PhoneBook.Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Contracts
{
    public interface IPhoneBookRepository
    {
        Task<IEnumerable<EntryEntity>> GetAsync(string name, Guid userId);
        Task SaveAsync(EntryEntity phoneBookEntry);
        Task<bool> ExistAsync(string name);
    }
}
