using Academy.Services.RoleAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Academy.Services.UserAPI.Models
    {
        public class User
        {
            public int UserId { get; set; }

            [Required]
            [StringLength(50)]
            public string UserName { get; set; }

            [Required]
            [StringLength(50)]
            public string UserSurname { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [ForeignKey("Role")]
            public int RoleId { get; set; }
            public virtual Role Role { get; set; }

        }
    }
