using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
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
        public IActionResult Admin()
        {
            string userEmail = HttpContext.Session.GetString("userEmail");
            var user = _context.Users.First(u => u.Email == userEmail);
            if (user.RoleId == 1)
            {
                var allUser = _context.Users.Where(u => u.Email != userEmail);

                ViewData["allUser"] = allUser;
                ViewData["role"] = _context.Roles;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Delete(string email)
        {
            var user = _context.Users.First(u => u.Email == email);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection values)
        {
            string email, password;
            email = values["email"];
            password = values["password"];
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.msg = "Invalid username or password!";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("userEmail", user.Email);
                HttpContext.Session.SetString("userName", user.Name);
                return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        public IActionResult Register([Bind("Email", "Password", "Phone", "Name", "Address", "Age", "PhotoLink", "RoleId")] User user)
        {
            if (emailExist(user.Email))
            {
                ViewBag.msg = "Email existed";
                return View();
            }
            else
            {
                if (phoneExist(user.Phone))
                {
                    ViewBag.msg = "Phone existed";
                    return View();
                }
                else
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    ViewBag.msg = "Register successfully!";
                    return View();
                }
            }

        }
        public IActionResult ChangePassword()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(IFormCollection values)
        {
            string userEmail = HttpContext.Session.GetString("userEmail");
            var oldPassword = values["oldPassword"];
            var newPassword = values["newPassword"];
            var user = await _context.Users.FirstAsync(u => u.Email == userEmail);
            if (checkPassword(user, oldPassword))
            {
                user.Password = newPassword;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                ViewBag.msg = "Change password success";
            }
            else
            {
                ViewBag.msg = "Old password invalid!!";
            }
            return RedirectToAction("Profile");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IFormFile file,[Bind("Email", "Password", "Phone", "Name", "Address", "Age", "PhotoLink", "RoleId")] User user)
        {
            if (emailExist(user.Email))
            {
                ViewBag.msg = "Email existed";
                return RedirectToAction("Profile");
            }
            else
            {
                if (phoneExist(user.Phone))
                {
                    ViewBag.msg = "Phone existed";
                    return RedirectToAction("Profile");
                }
                else
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                        using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileSrteam);
                        }
                        user.PhotoLink = "img/" + fileName;
                    }
                    
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    ViewBag.msg = "Update information successfully!";
                    return RedirectToAction("Profile");
                }
            }


        }
        public async Task<IActionResult> Profile()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            var user = await _context.Users
                .FirstAsync(u => u.Email == userEmail);

            return View(user);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("user", "");
            return RedirectToAction(nameof(Index), nameof(HomeController));
        }
        private Boolean emailExist(string email)
        {
            return _context.Users.First(u => u.Email == email) != null ? true : false;
        }
        private Boolean phoneExist(string phone)
        {
            return _context.Users.First(u => u.Phone == phone) != null ? true : false;
        }
        private Boolean checkPassword(User user, string oldPassword)
        {
            return user.Password == oldPassword ? true : false;
        }
    }

}
