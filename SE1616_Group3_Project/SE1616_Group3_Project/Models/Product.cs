using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductQuantities = new HashSet<ProductQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string PhotoLink { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual CartItem CartItem { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
