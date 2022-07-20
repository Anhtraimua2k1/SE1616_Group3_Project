using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly BakingIngredientsContext _context;
        public OrderController(BakingIngredientsContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            string userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == "")
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var order = _context.Orders
                    .Include(o => o.OrderItems)
                    .Where(o => o.UserEmail == userEmail);
                ViewData["orders"] = order;
                return View();
            }

        }
        public IActionResult Admin()
        {
            string userEmail = HttpContext.Session.GetString("userEmail");


            var user = _context.Users.First(u => u.Email == userEmail);
            if (user.RoleId != 3)
            {
                var order = _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserEmail == userEmail);
                ViewData["orders"] = order;
                return View();

            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Add([Bind("Id", "UserEmail", "Amount", "PaymentMethod", "PaymentStatus")] Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            int orderId = order.Id;

            return RedirectToAction("Index");

        }
      

    }
}
