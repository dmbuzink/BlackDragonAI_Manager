﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: 39, MinimumLength = 3, ErrorMessage = "Should be between 3 and 39 characters (inclusive)")]
        public string Username { get; set; }

        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Should be between 1 and 255 characters (inclusive)")]
        public string Password { get; set; }
    }
}
