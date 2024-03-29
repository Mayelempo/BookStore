using BookStore.BusinessLogic.Dtos.Books;
using BookStore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Presentation.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync(BookDto book, CancellationToken cancellationToken)
        {
            var result = await _bookService.AddAsync(book, cancellationToken);
            return Ok(result); 
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _bookService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(BookDto book, CancellationToken cancellationToken )
        {
            var result = await _bookService.DeleteAsync(book, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBookByDescriptionAsync(string bookDescription, CancellationToken cancellationToken) 
        {
            var result = await _bookService.GetBookByDescriptionAsync(bookDescription, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{name}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult>GetBookByName (string name, CancellationToken cancellationToken) 
        
        {
            var result = await _bookService.GetBookByNameAsync(name, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(BookDto book, CancellationToken cancellationToken)
        {
            var result = await _bookService.GetByIdAsync(book, cancellationToken);
            return Ok(result);
        }



        [HttpPut("{UserCreateDto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(BookDto book, CancellationToken cancellationToken)
        {
            var result = await _bookService.UpdateAsync(book, cancellationToken);
            return Ok(result);
        }
    }
}
