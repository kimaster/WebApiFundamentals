using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models
{
    public class PointOfInterestCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Discription { get; set; }
    }
}
