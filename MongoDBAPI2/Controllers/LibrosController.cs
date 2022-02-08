using Microsoft.AspNetCore.Mvc;
using MongoDBAPI2.Models;
using MongoDBAPI2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : Controller
    {
        private readonly BooksService _booksService;

        public LibrosController(BooksService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<Libro>> Get() =>
            await _booksService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Libro>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Libro libro)
        {
            await _booksService.CreateAsync(libro);

            return CreatedAtAction(nameof(Get), new { id = libro.Id }, libro);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody]Libro libro)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            libro.Id = book.Id;

            await _booksService.UpdateAsync(id, libro);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.RemoveAsync(book.Id);

            return NoContent();
        }
    }
}
