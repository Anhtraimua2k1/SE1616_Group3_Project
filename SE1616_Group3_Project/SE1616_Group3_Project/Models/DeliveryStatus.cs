using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class DeliveryStatus
    {
        public int? OrderItem { get; set; }
        public string DeliveryUnit { get; set; }
        public string ShippingStatus { get; set; }
        public bool ShippingCompleted { get; set; }

        public virtual OrderItem OrderItemNavigation { get; set; }
    }
}
