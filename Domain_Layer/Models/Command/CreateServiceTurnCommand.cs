using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class CreateServiceTurnCommand
    {
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int TurnId { get; set; }
    }
}
