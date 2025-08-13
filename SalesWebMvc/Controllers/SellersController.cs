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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // If the ID is null, return a NotFound result
            }
            var obj = _sellerService.FindById(id.Value); // Find the seller by ID
            if (obj == null)
            {
                return NotFound(); // If the seller is not found, return a NotFound result
            }
            return View(obj); // If found, return the view with the seller object
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index)); // Redirect to the Index action after deletion
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); 
            }
            var obj = _sellerService.FindById(id.Value); 
            if (obj == null)
            {
                return NotFound(); 
            }
            return View(obj); 
        }
    }
}
