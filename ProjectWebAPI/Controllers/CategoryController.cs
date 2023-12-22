using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using ProjectWebAPI.Models.Categories.RequestModels;
using ProjectWebAPI.Models.Categories.ResponeModels;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel item)
        {
            Category c = new()
            {
                CategoryName = item.CategoryName,
                Description = item.Description,
            };
            string result = _categoryManager.Add(c);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponseModel> categories = _categoryManager.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description= x.Description,
                CategoryID=x.ID

            }).ToList();
            return Ok(categories);
        }
    }
}
