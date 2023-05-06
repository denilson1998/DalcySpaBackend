using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
    }
}
