using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuroTrack.Models
{
    public class Moment
    {
        [Key]
        public int MomentId { get; set; }

        [Required]
        public string MomentName { set; get; }

        [Required]
        [Range(1, 10)]
        public int Intensity { set; get; }

        public decimal? EstimatedDuration { set; get; }

        [Required]
        [MaxLength(255)]
        public string Description { set; get; }

        [Required]
        public int UserId { set; get; }

        [ForeignKey(nameof(UserId))]
        public User? User { set; get; }

        [Required]
        public int MomentTypeId { set; get; }

        [ForeignKey(nameof(MomentTypeId))]
        public MomentType? MomentType { set; get; }
    }
}
