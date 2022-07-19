using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly BakingIngredientsContext _context;

        public UserController(BakingIngredientsContext context)
        {
            this._context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection values)
        {
            string email, password;
            email = values["email"];
            password = values["password"];
            var user = await _context.Users
                .Include(u => u.Role)

                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                return View("Invalid email or password!");
            }
            else
            {
                HttpContext.Session.SetString("user", email);
            }
            return RedirectToAction(nameof(Index), nameof(HomeController));

        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("user", "");
            return RedirectToAction(nameof(Index), nameof(HomeController));
        }
    }

}
