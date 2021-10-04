using Api1.DAL;
using Api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetBook()
        {
            var book = _context.Book.ToList();
            if (book is null)
                return NotFound();
            return Ok(book);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetBookById(int id)
        {
            var book = _context.Book.FirstOrDefault(m => m.Id == id);
            if (book is null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public ActionResult Create([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Book.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id,[FromBody] Book book)
        {
            var bookDb = _context.Book.FirstOrDefault(m => m.Id == id);
            if (bookDb is null)
                return NotFound();
            book.Id = bookDb.Id;
            book.Name = bookDb.Name;
            book.Price = bookDb.Price;
            _context.SaveChanges();
            return Ok(book);
        }

       
    }


}
