using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class ServiceTurn
    {
        public int ServiceId { get; set; }
        public int TurnId { get; set; }
    }
}
