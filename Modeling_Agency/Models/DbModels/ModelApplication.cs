using System.ComponentModel.DataAnnotations;

namespace Modeling_Agency.Models.DbModels
{
    public class ModelApplication
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime? Dob { set; get; }
        public string? Location { set; get; }
        public string? Description { set; get; }
        public float? Rate { get; set; }
        public string? ImgUrl { set; get; }
        public string? Phone { set; get; }
        public string? Gender { set; get; }
        public int? Weight { set; get; }
        public int? Height { set; get; }
        public DateTime? ApplicationDate { set; get; }
        public string? Category { set; get; }
        public string? ApplicationStatus { set; get; }
    }
}
