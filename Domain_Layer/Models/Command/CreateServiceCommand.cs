﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class CreateServiceCommand
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
