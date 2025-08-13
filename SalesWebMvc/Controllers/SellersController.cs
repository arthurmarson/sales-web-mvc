using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() 
        {
            var list = _sellerService.FindAll(); // Create a list of sellers from the service
            return View(list);  // Activate the View that are on Sellers/Index.cshtml and pass the list of sellers to it
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller); 
            return RedirectToAction(nameof(Index));
        }
    }
}
