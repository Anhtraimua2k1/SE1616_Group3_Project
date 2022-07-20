using Microsoft.AspNetCore.Mvc;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly BakingIngredientsContext _context;
        public FeedbackController(BakingIngredientsContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            string userEmail = HttpContext.Session.GetString("userEmail");
            var user = _context.Users.First(u => u.Email == userEmail);
            if (user.RoleId == 1)
            {
                var feedback = _context.Feedbacks;
                ViewData["feedback"] = feedback;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public IActionResult ChangeStatus(IFormCollection values)
        {
            int orderItemId = int.Parse(values["orderItemId"]);
            string feedbackWriter = values["feedbackWriter"];
            var feedback = _context.Feedbacks.First(f => f.OrderItem == orderItemId && f.FeedbackWritter == feedbackWriter);
            if(feedback.FeedbackEnable == true)
            {
                feedback.FeedbackEnable = false;
            } else
            {
                feedback.FeedbackEnable = true;
            }
            _context.Feedbacks.Update(feedback);
            _context.SaveChanges();

            return RedirectToAction("Admin");
        }
        [HttpPost]
        public IActionResult Add([Bind("FeedbackWritter", "OrderItem", "FeedbackPhoto", "FeedbackDetail", "FeedbackEnable")] Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
        [HttpPost]
        public IActionResult Edit([Bind("FeedbackWritter", "OrderItem", "FeedbackPhoto", "FeedbackDetail", "FeedbackEnable")] Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }




    }
}
