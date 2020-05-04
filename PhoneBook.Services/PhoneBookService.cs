using System;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Core.Exceptions;
using PhoneBook.Core.Models;
using PhoneBook.Core.Models.DTOs;
using PhoneBook.Core.Models.Entities;
using PhoneBook.Services.Extensions;
using PhoneBook.Repository.Contracts;
using PhoneBook.Services.Contracts;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<ServiceResponse<AddPhoneBookEntryResponse>> AddEntry(AddPhoneBookEntryRequest phoneBookEntry, Guid userId)
        {
            var bookEntryRecord = phoneBookEntry.MapGeneric<EntryEntity, AddPhoneBookEntryRequest>();
            bookEntryRecord.PhoneBookId = userId;

            if (await _phoneBookRepository.ExistAsync(phoneBookEntry.Name))
            {
                throw new BadRequestException("Entry already exist");
            }

            await _phoneBookRepository.SaveAsync(bookEntryRecord);

            return new ServiceResponse<AddPhoneBookEntryResponse>("Successfully added an entry")
            {
                Data = new AddPhoneBookEntryResponse
                {
                    IsAdded = true
                }
            };
        }

        public async Task<ServiceResponse<SearchPhoneBookResponse>> Search(SearchPhoneBookRequest searchPhoneBook, Guid userId)
        {
            var searchResults = await _phoneBookRepository.GetAsync(searchPhoneBook.Name, userId);

            var entries = searchResults.Select(entry => entry.MapGeneric<PhoneBookEntry, EntryEntity>()).ToList();

            return new ServiceResponse<SearchPhoneBookResponse>("Successfully received search results")
            {
                Data = new SearchPhoneBookResponse
                {
                    PhoneBookEntries = entries
                }
            };
        }
    }
}
