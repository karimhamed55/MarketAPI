using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.data;
using webAPI.DTO;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MarketDbContext _context;

        public CategoryController(MarketDbContext context)
        {
            _context = context;
        }
       
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<CategoryDTO> GetbyID (int id)

        {
            var category = _context.Categories.Include(x => x.Products)
                .FirstOrDefault(x => x.Id == id);

                if (category == null)
                return NotFound();

            var dto = new CategoryDTO
            {
                id = category.Id,
                name = category.Name,
                Products = category.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };
            return Ok(dto);
        }




    }
}
