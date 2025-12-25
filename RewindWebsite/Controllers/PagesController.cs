using Microsoft.AspNetCore.Mvc;

namespace RewindWebsite.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Terms()
        {
            ViewData["Title"] = "Terms of Service - Rewind Snacks";
            ViewData["MetaDescription"] = "Terms and conditions for Rewind snacks. Learn about our policies, quality guarantees, and customer commitments.";

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Policy - Rewind Snacks";
            ViewData["MetaDescription"] = "Privacy policy for Rewind. Learn how we protect your data and information.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact Us - Rewind Snacks";
            ViewData["MetaDescription"] = "Contact Rewind snacks for wholesale inquiries, customer support, and partnership opportunities.";

            return View();
        }
    }
}