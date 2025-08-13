using Microsoft.AspNetCore.Mvc;
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
    }
}
