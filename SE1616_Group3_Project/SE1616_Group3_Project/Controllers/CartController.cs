using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly BakingIngredientsContext _context;
        public CartController(BakingIngredientsContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            var cart = _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserEmail == userEmail);

            ViewData["CartItems"] = cart;
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await _context.CartItems.FirstAsync(c => c.ProductId == id);
            _context.CartItems.Remove(cart);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var cart = await _context.CartItems.FirstAsync(c => c.ProductId == id);
            var product = await _context.Products.FirstAsync(p => p.Id == id);
            if(quantity < product.Quantity)
            {
                cart.Quantity = quantity;
                _context.CartItems.Update(cart);
                _context.SaveChanges();
            } else
            {
                ViewBag.msg = "Out of stock!";
            }
           

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add([Bind("ProductId,Quantity,UserEmail,AddedDate")] CartItem cartItem)
        {
            var cart = cartExist(cartItem.ProductId);
            if (cart == null)
            {
                _context.CartItems.Add(cartItem);

            }
            else
            {
                cart.Quantity += 1;
                _context.CartItems.Update(cart);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        private CartItem cartExist(int productId)
        {
            return _context.CartItems.First(c => c.ProductId == productId);
        }

    }
}
