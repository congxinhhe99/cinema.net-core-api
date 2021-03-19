﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_core.Form
{
    public class UserRequest
    {
        [Required]
        public string Username
        {
            get; set;
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName
        {
            get; set;
        }

        [Required]
        public string Password
        {
            get; set;
        }
    }
}