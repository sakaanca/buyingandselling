using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using ProjectWebAPI.Models.Products.RequestModels;
using ProjectWebAPI.Models.Products.ResponeModels;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel item)
        {
            Product p = new()
            {
                ProductName = item.ProductName,
                UnitPrice = item.UnitPrice,
                CategoryID = item.CategoryID
            };

            string result = _productManager.Add(p);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? categoryID)
        {
            List<ProductResponseModel> products;

            if (categoryID.HasValue)
            {
                products = _productManager.Where(x => x.CategoryID == categoryID).Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }
            else
            {
                products = _productManager.Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }

            return Ok(products);
        }
    }
}
