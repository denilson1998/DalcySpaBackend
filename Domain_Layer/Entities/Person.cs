using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Ci { get; set; } = string.Empty; 

        public string CellphoneNumber { get; set; } = string.Empty;

        public int UserId { get; set; }

    }

    public class Client : Person
    {
        public int PersonId { get; set; }

    }

    public class Beautician : Person
    {
        public int PersonId { get; set;}
    }
}
