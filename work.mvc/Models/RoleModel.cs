using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class EditRoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
