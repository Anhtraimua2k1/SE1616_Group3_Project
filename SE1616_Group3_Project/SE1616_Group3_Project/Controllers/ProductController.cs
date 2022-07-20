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
            var categories = _context.Categories
                .Include(c => c.Products);


            ViewData["Categories"] = categories.ToList();

            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .First(p => p.Id == id);

            var feedback = _context.Feedbacks
                .Include(f => f.OrderItem)
                .Where(f => f.OrderItemNavigation.ProductName == product.Name && f.FeedbackEnable==true);

            ViewData["feedback"] = feedback;
            

            return View(product);
        }
        public async Task<IActionResult> Admin()
        {
            string userEmail = HttpContext.Session.GetString("userName");
            var user = await _context.Users.Include(u => u.Role).FirstAsync(u => u.Equals("admin"));
            if (user.RoleId == 3)
            {
                return RedirectToAction("Index");
            }
            else
            {

                var categories = _context.Categories.Include(c => c.Products);
                ViewData["Categories"] = categories.ToList();

                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([Bind("Id,Category1")] Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory([Bind("Id,Category1")] Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstAsync(u => u.Id == id);
            foreach (Product p in category.Products)
            {
                _context.Products.Remove(p);
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name", "Detail", "PhotoLink", "Price", "Quantity", "CategoryId")] Product product)
        {
            await _context.Products.AddAsync(product);

            return RedirectToAction("Admin");
        }
        [HttpPost]
        public IActionResult Update([Bind("Id", "Name", "Detail", "PhotoLink", "Price", "Quantity", "CategoryId")] Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Include(p => p.CartItems)
                .Include(p => p.ProductQuantities)
                .FirstAsync(p => p.Id == id);

            foreach (CartItem c in product.CartItems)
            {
                _context.CartItems.Remove(c);
            }
            foreach (ProductQuantity pq in product.ProductQuantities)
            {
                _context.ProductQuantities.Remove(pq);
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }
        //[HttpPost]
        /*public IActionResult UpdateQuantity([Bind("ProductId", "ShopId", "Quantity", "UpdateDate")] ProductQuantity productQuantity)
        {
            int quantity = 0;
            productQuantity.UpdateDate = DateTime.Now;
            _context.Add(productQuantity);
            _context.SaveChanges();
            var quantityInShop = _context.ProductQuantities
                
                
                .Where(p => p.ProductId == productQuantity.ProductId);
                
                
            foreach(ProductQuantity pq in quantityInShop)
            {
                quantity += 0;
            }
                
        }*/
    }
}
