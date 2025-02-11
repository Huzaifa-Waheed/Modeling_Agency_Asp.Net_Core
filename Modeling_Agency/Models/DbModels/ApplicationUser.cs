using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Modeling_Agency.Models.DbModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public override string? PhoneNumber { get => base.PhoneNumber   ; set => base.PhoneNumber = value; }
        public string Role { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
