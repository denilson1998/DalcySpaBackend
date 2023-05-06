using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class UserCommand
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Ci { get; set; } = string.Empty;

        [Required]
        public string CellphoneNumber { get; set; } = string.Empty;

        [Required]
        public int RoleId { get; set; }
    }
}
