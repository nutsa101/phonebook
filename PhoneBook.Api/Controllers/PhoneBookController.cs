using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Filter;
using PhoneBook.Core.Models;
using PhoneBook.Core.Models.DTOs;
using PhoneBook.Services.Contracts;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [ExceptionFilter]
    [Route("api/phoneBook")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet]
        [ServiceFilter(typeof(AuthorizationFilter))]
        [ProducesResponseType(typeof(ServiceResponse<SearchPhoneBookResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchPhoneBook([FromQuery]SearchPhoneBookRequest searchPhoneBookRequest)
        {
            var response = await _phoneBookService.Search(searchPhoneBookRequest, GetUserToken().UserId);
            return Ok(response);
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        [ProducesResponseType(typeof(ServiceResponse<AddPhoneBookEntryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddEntry(AddPhoneBookEntryRequest addPhoneBookEntryRequest)
        {
            var response = await _phoneBookService.AddEntry(addPhoneBookEntryRequest, GetUserToken().UserId);
            return Created(string.Empty, response);
        }
    }
}
