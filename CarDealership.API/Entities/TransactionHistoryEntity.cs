using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.API.Entities
{
    public class TransactionHistoryEntity
    {
        [Key]
        public int TransID { get; set; }

        [Required]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public PurchaseOrderEntity? PurchaseOrder { get; set; }

        public DateTime Date { get; set; }
    }
}
