using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Library.Models;
using My_Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Library.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Book book = await _bookRepository.Get(id);

                if (book == null) return NotFound();

                return Ok(book);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _bookRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("genres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetGenres()
        {
            try
            {
                return Ok(GetEnum(typeof(Genre)));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private IEnumerable<EnumDTO> GetEnum(Type enumType)
        {
            return Enum.GetValues(enumType)
              .Cast<int>()
              .Select(e => new EnumDTO() { Key = e, Value = Enum.GetName(enumType, e) });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                Book deletedBook = await _bookRepository.Delete(id);

                if (deletedBook == null) return NotFound();

                return Ok(deletedBook);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Book>> Update(Book book)
        {
            try
            {
                if (book == null) return BadRequest();

                Book updatedBook = await _bookRepository.Update(book);

                if (updatedBook == null) return BadRequest();

                return Ok(updatedBook);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Book>> Add(Book book)
        {
            try
            {
                if (book == null) return BadRequest();

                Book createdBook = await _bookRepository.Add(book);

                if (createdBook == null) return BadRequest();

                return CreatedAtAction(nameof(GetAll), new { id = createdBook.Id }, createdBook);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        private class EnumDTO
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
