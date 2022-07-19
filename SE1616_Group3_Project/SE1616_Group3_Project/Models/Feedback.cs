using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class Feedback
    {
        public string UserEmail { get; set; }
        public int OrderItem { get; set; }
        public string FeedbackPhoto { get; set; }
        public string FeedbackDetail { get; set; }
        public int? FeedbackRate { get; set; }

        public virtual OrderItem OrderItemNavigation { get; set; }
        public virtual User UserEmailNavigation { get; set; }
    }
}
