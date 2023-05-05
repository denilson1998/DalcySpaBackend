using System.ComponentModel.DataAnnotations;

namespace Application_Layer.Endpoints.Roles
{
    public class CreateRoleCommand
    {
        [Required]
        public string Description { get; set; }
    }
}
