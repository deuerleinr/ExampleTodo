﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ToDoCreate
    {
        [Required]
        public string Task { get; set; }
    }
}