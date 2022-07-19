using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly BakingIngredientsContext _context;
        public ProductController(BakingIngredientsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.Products);
            ViewData["Categories"] = categories.ToList();
           
            return View();
        }
        
    }
}
