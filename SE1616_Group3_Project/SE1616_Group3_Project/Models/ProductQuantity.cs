﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class ProductQuantity
    {
        public int ProductId { get; set; }
        public int ShopId { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
