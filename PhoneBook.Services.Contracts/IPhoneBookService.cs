using System;
using System.Threading.Tasks;
using PhoneBook.Core.Models;
using PhoneBook.Core.Models.DTOs;

namespace PhoneBook.Services.Contracts
{
    public interface IPhoneBookService
    {
        Task<ServiceResponse<AddPhoneBookEntryResponse>> AddEntry(AddPhoneBookEntryRequest phoneBookEntry, Guid userId);
        Task<ServiceResponse<SearchPhoneBookResponse>> Search(SearchPhoneBookRequest searchPhoneBook, Guid userId);
    }
}
