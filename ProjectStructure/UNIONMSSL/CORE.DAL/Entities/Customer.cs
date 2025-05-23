﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
    }
}
