using System.ComponentModel.DataAnnotations;

namespace CarDealership.API.Entities
{
    public class CarsEntity
    {
        [Key]
        public int VIN { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; }
        public string YearVersion { get; set; } 
        public string PlateNumber { get; set; }
        public string CarType { get; set; } 
    }
}
