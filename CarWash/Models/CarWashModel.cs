using System.ComponentModel.DataAnnotations;

namespace CarWash.Models
{
    public class CarWashModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "")]
        public string Car { get; set; }


        [Required(ErrorMessage = "")]
        public string EntryTime { get; set; }

        public string? ExitTime { get; set; }

        [StringLength(200)]
        public string? Obs { get; set; }

        [Required(ErrorMessage = "")]
        public float Price { get; set; }

        [StringLength(8)]
        public string? LicensePlate { get; set; }

    }
}
