using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.API.Entities
{
    public class CustomersEntity
    {
        [Key]
        public int CustomerID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        [SwaggerSchema(Format = "date", Description = "Birthdate in yyyy-MM-dd format")]
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
    }
}
