using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() 
        {
            var list = _sellerService.FindAll(); // Create a list of sellers from the service
            return View(list);  // Activate the View that are on Sellers/Index.cshtml and pass the list of sellers to it
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); // Get all departments from the service
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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
