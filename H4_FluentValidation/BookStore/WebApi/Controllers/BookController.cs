using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooksId;
using WebApi.BookOperations.UpdateBooks;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBooksId.GetBooksIdQuery;
using static WebApi.BookOperations.UpdateBooks.UpdateBookCommand;

namespace WebApi.AddControllers
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
            try
            {
                GetBooksIdQuery query = new GetBooksIdQuery(_context, _mapper);
                query.BookId = id;

                GetBooksIdQueryValidator validator = new GetBooksIdQueryValidator(); // Fluent Validation added
                validator.ValidateAndThrow(query); 

                result = query.Handle(); // Model View
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(b => b.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book; 
        // }

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                
                if(!ModelState.IsValid) // Fluent Validation added
                    return BadRequest(ModelState);

                command.Handle(); // Model View
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(GetBooks),command);
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updateBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator(); // Fluent Validation added
                validator.ValidateAndThrow(command);

                command.Handle(); // Model View
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator(); // Fluent Validation added
                validator.ValidateAndThrow(command); 

                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}