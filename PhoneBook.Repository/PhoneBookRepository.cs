using System;
using PhoneBook.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Models.Entities;
using PhoneBook.Data;

namespace PhoneBook.Repository
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookDataContext _dataContext;

        public PhoneBookRepository(PhoneBookDataContext phoneBookDataContext)
        {
            _dataContext = phoneBookDataContext;
        }

        public async Task<IEnumerable<EntryEntity>> GetAsync(string name, Guid userId)
        {
            return await _dataContext.Entries.Where(x => x.Name.Contains(name) && x.PhoneBookId == userId).ToListAsync();
        }

        public async Task SaveAsync(EntryEntity phoneBookEntry)
        {
            await _dataContext.Entries.AddAsync(phoneBookEntry);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _dataContext.Entries.AnyAsync(x => x.Name == name);
        }
    }
}
