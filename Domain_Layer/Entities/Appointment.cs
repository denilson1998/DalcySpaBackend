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
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int BeauticianId { get; set; }
        public int ServiceId { get; set; }
        public int TurnId { get; set; }
    }
}
