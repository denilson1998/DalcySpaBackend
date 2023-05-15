using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class CreateAppointmentCommand
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int BeauticianId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int TurnId { get; set; }
    }
}
