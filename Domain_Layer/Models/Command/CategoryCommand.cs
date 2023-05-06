using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class CategoryCommand
    {
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
