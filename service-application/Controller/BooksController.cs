using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Services;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly SkillCategoryService _skillCategory;

        public BooksController(BookService bookService, SkillCategoryService skillCategory)
        {
            _bookService = bookService;
            _skillCategory = skillCategory; 
        }



        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookService.GetBooks();
            var asd = _skillCategory.GetSzar();
            return Ok(asd);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}