﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
