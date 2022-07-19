using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string ProductName { get; set; }
        public string PhotoLink { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? BoughtDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
