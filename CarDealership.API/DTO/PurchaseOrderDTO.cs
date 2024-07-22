using CarDealership.API.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarDealership.API.DTOs
{
    public record PurchaseOrderDTO
    {
        public int OrderID { get; set; }
        public int VIN { get; set; }
        public int CustomerID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string YearVersion { get; set; }
        public string PlateNumber { get; set; }
        public string CarType { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        [SwaggerSchema(Format = "date", Description = "Birthdate in yyyy-MM-dd format")]
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
    }
}