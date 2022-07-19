using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string PhotoLink { get; set; }
        public bool? EnableStatus { get; set; }
        public string Owner { get; set; }

        public virtual User OwnerNavigation { get; set; }
    }
}
