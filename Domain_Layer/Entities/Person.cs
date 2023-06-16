using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Ci { get; set; } = string.Empty; 

        public string CellphoneNumber { get; set; } = string.Empty;

    }

    public class Client
    {
        [Key]
        public int PersonId { get; set; }

    }

    public class Beautician
    {
        [Key]
        public int PersonId { get; set;}
    }
}
