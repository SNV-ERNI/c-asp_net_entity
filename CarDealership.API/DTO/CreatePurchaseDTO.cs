using System.Text.Json.Serialization;

namespace CarDealership.API.DTOs
{
    public record CreatePurchaseOrderDTO
    {
        public int VIN { get; set; }
        public int CustomerID { get; set; }

    }
}