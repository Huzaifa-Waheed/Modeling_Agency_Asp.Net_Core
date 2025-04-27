using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modeling_Agency.Models.DbModels
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
        public string? Title { get; set; }
        public string? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public ApplicationUser client { get; set; }
        public int? ModelId { get; set; }
        [ForeignKey("ModelId")]
        public Model model { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
