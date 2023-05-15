using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Result
{
    public class CreateAppointmentResult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int BeauticianId { get; set; }
        public int ServiceId { get; set; }
        public int TurnId { get; set; }
    }
}
