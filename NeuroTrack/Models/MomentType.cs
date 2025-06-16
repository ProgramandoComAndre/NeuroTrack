using System.ComponentModel.DataAnnotations;

namespace NeuroTrack.Models
{
    public class MomentType
    {
        [Key]
        public int MomentTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public IList<Moment> Moments { get; set; }
    }
}
