using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Interface;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View();
        }
    }
}
