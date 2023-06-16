using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Observation
    {
        [Key]
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public int AppointmentId { get; set; }
    }
}
