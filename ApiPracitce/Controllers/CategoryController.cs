using ApiPracitce.Dtos.CategoryDtos;
using ApiPractice.Data;
using ApiPractice.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPracitce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly StoreDbContext _context;
        public CategoryController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==id);

            if (category==null)
            {
                return NotFound();
            }

            CategoryGetDto categoryDto = new CategoryGetDto { 
            
                Id= category.Id,
                Name= category.Name
            
            };

            return Ok(categoryDto);
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            var categories = _context.Categories.Skip((page - 1) * 4).Take(4).ToList();

            var categoryGetListItemDto = _context.Categories.Select(x => new CategoryGetListItemDto { Id = x.Id, Name = x.Name }).Skip((page - 1) * 4).Take(4).ToList();

            return Ok(categoryGetListItemDto);
        }

        [HttpPost("")]
        public IActionResult Create(CategoryPostDto categoryDto)
        {
            Category category = new Category { 
            
                Name = categoryDto.Name

            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return Created("", categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,CategoryPostDto categoryDto)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category==null)
            {
                return NotFound();
            }

            category.Name = categoryDto.Name;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
