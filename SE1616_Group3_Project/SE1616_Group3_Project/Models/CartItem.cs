﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User UserEmailNavigation { get; set; }
    }
}
