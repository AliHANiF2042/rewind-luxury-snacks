using Microsoft.AspNetCore.Mvc;
using RewindWebsite.Database;
using RewindWebsite.Models.ViewModels;
using RewindWebsite.Models;

namespace RewindWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(string category = null)
        {
            ViewData["Title"] = "Our Products - Luxury Snacks Collection";
            ViewData["MetaDescription"] = "Browse Rewind's collection of delicious, elegant snacks. Premium quality served in 5-star restaurants at budget-friendly prices.";

            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.category == category);
                ViewData["Title"] = $"{category} - Rewind Luxury Snacks";
            }

            var productList = products.ToList();
            var categories = _context.Products.Select(p => p.category).Distinct().ToList();

            var model = new ProductsViewModel
            {
                Products = productList,
                Categories = categories,
                SelectedCategory = category
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["Title"] = $"{product.name} - Rewind Luxury Snack";
            ViewData["MetaDescription"] = product.SEODescription;
            ViewData["Keywords"] = product.SEOKeywords;

            return View(product);
        }
    }
}