using System;
using System.Collections.Generic;

namespace SE1616_Group3_Project.Models
{
    public partial class Feedback
    {
        public string FeedbackWritter { get; set; } = null!;
        public int OrderItem { get; set; }
        public string? FeedbackPhoto { get; set; }
        public string FeedbackDetail { get; set; } = null!;
        public bool? FeedbackEnable { get; set; }

        public virtual User FeedbackWritterNavigation { get; set; } = null!;
        public virtual OrderItem OrderItemNavigation { get; set; } = null!;
    }
}
