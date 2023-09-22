using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Queries.GetBooksId;
using WebApi.DbOperations;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Queries.GetBooksId.GetBooksIdQuery;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.UpdateBooks;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result =  query.Handle(); // Model View
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            BooksIdViewModel result;
            GetBooksIdQuery query = new GetBooksIdQuery(_context, _mapper);
            query.BookId = id;

            GetBooksIdQueryValidator validator = new GetBooksIdQueryValidator(); // Fluent Validation added
            validator.ValidateAndThrow(query); 

            result = query.Handle(); // Model View

            return Ok(result);
        }

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
                
            CreateBookCommandValidator validator = new CreateBookCommandValidator(); // Fluent Validation added
            validator.ValidateAndThrow(command);

            command.Handle(); // Model View
            return CreatedAtAction(nameof(GetBooks),command);
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updateBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(); // Fluent Validation added
            validator.ValidateAndThrow(command);

            command.Handle(); // Model View

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
                
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator(); // Fluent Validation added
            validator.ValidateAndThrow(command); 

            command.Handle();

            return NoContent();
        }
    }
}