using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarDealership.API.Entities
{
    public class PurchaseOrderEntity
    {
        [Key]
        [JsonIgnore]
        public int OrderID { get; set; }

        [Required]
        public int VIN { get; set; }
        [ForeignKey("VIN")]
        public CarsEntity? Car { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public CustomersEntity? Customer { get; set; }

    }
}
