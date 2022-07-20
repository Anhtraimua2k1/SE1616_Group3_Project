using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly BakingIngredientsContext _context;
        public BlogController(BakingIngredientsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            var blog = _context.Blogs
            .Include(b => b.Owner)
            .Where(b => b.EnableStatus == true);
            ViewData["blogs"] = blog;

            return View();


        }
        public async Task<IActionResult> Detail (int id)
        {


            var blog = await _context.Blogs
            .Include(b => b.Owner)
            .FirstOrDefaultAsync(b => b.Id == id);
            

            return View(blog);


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
                var blog = _context.Blogs
            .Include(b => b.Owner);

                ViewData["blogs"] = blog;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Title", "Detail", "PhotoLink", "EnableStatus", "Owner")] Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id", "Title", "Detail", "PhotoLink", "EnableStatus", "Owner")] Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _context.Blogs.FirstAsync(b => b.Id == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
    }
}
