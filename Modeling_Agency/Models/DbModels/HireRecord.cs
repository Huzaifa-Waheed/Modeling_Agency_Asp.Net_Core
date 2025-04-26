using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modeling_Agency.Models.DbModels
{
    public class HireRecord
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public float Amount { set; get; }
        public string? State { set; get; }
        public DateTime? StateDate { set; get; }
        public DateTime? RequestedDate { set; get; }
        public string? Description { set; get; }
        public bool IsActive { set; get; }
        public int? ModelId { set; get; }
        [ForeignKey("ModelId")]
        public Model model { set; get; }
        public string? ClientId { set; get; }
        [ForeignKey("ClientId")]
        public ApplicationUser client { set; get; }
    }
}
