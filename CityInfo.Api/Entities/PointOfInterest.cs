using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public City? city { get; set; } //
        [ForeignKey("CityId")]
        public int CiityId { get; set; }

        public PointOfInterest(string name)
        {
            this.Name = name;
        }



    }
}