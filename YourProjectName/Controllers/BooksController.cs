using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetPdfFiles()
        {
            var booksPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "storage", "books");

            if (!Directory.Exists(booksPath))
            {
                return NotFound("Books directory does not exist.");
            }

            var pdfFiles = Directory.GetFiles(booksPath, "*.pdf")
                                    .Select(Path.GetFileName)
                                    .ToArray();

            return Ok(pdfFiles);
        }

        
        [HttpGet("{bookname}")]
        public IActionResult GetPdfFile(string bookname)
        {
            var booksPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "storage", "books");

            if (!Directory.Exists(booksPath))
            {
                return NotFound("Books directory does not exist.");
            }

            var filePath = Path.Combine(booksPath, bookname);

            
            if (!System.IO.File.Exists(filePath) || Path.GetExtension(filePath).ToLower() != ".pdf")
            {
                return NotFound("File not found or is not a PDF.");
            }

            
            return PhysicalFile(filePath, "application/pdf");
        }
    }
}
