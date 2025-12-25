using Microsoft.AspNetCore.Mvc;
using RewindWebsite.Database;
using RewindWebsite.Services;
using RewindWebsite.Models.ViewModels;
using RewindWebsite.Models;

namespace RewindWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private readonly iSeoServices _seoService;

        public HomeController(Context context, iSeoServices seoService)
        {
            _context = context;
            _seoService = seoService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Rewind - Luxury Snacks at Affordable Prices";
            ViewData["MetaDescription"] = "Rewind creates delicious, elegant snacks served in 5-star restaurants nationwide. Premium quality at budget-friendly prices.";
            ViewData["Keywords"] = "luxury snacks, affordable gourmet, 5-star restaurant snacks, premium snacks, budget-friendly luxury";

            var featuredProducts = _context.Products
                .Where(p => p.isFeatured)
                .Take(4)
                .ToList();

            var teamMembers = _context.TeamMembers.ToList();

            var model = new HomeViewModel
            {
                FeaturedProducts = featuredProducts,
                TeamMembers = teamMembers
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Rewind - Our Story & Mission";
            ViewData["MetaDescription"] = "Learn about Rewind's commitment to creating elegant, delicious snacks with attention to detail. Serving 5-star restaurants nationwide.";

            var teamMembers = _context.TeamMembers.ToList();
            return View(teamMembers);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}