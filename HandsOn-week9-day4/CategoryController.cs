using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CategoryService.Models;

namespace CategoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categories);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Category category)
        {
            categories.Add(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Category updated)
        {
            var category = categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null) return NotFound();

            category.CategoryName = updated.CategoryName;
            category.Description = updated.Description;

            return Ok(category);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null) return NotFound();

            categories.Remove(category);
            return Ok("Deleted");
        }
    }
}
