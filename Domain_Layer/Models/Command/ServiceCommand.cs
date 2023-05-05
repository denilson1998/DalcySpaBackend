using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Command
{
    public class ServiceCommand
    {
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
