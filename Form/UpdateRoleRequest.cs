using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_core.Form
{
    public class UpdateRoleRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public List<int> RoleIds { get; set; }
    }
}
