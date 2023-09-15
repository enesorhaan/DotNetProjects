using H1_RestfulApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H1_RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Name1", Price = 50},
            new Book { Id = 2, Name = "Name2", Price = 50}
        };


        // GetAll - GET: api/<BookController> 
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_books);
        }

        // GetById - GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);

            if(book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            int newBookId = _books.Count + 1;
            book.Id = newBookId;

            _books.Add(book);

            return CreatedAtAction(nameof(GetById), new { id = newBookId}, book);

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if(book == null)
                return BadRequest();

            Book newBook = _books.FirstOrDefault(b => b.Id == id);

            if (newBook == null)
                return NotFound();

            newBook.Name = book.Name;
            newBook.Price = book.Price;

            return Ok(newBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            Book newBook = _books.FirstOrDefault(b => b.Id == id);

            if(newBook == null)
                return NotFound();

            _books.Remove(newBook);

            return NoContent();
        }
    }
}
