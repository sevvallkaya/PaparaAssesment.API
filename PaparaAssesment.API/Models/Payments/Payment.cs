using PaparaAssesment.API.Models.Residents;
using PaparaAssesment.API.Models.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PaparaAssesment.API.Models.Flats;

namespace PaparaAssesment.API.Models.Payments
{
    public class Payment
    {

        [Key]
        public int PaymentId { get; set; }

        public int PaymentTypeId { get; set; }


        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }

        public DateTime CreatedDate { get; set; } =DateTime.Now;

        public DateTime? PaymentDate { get; set; }

        public bool IsPaid { get; set; }

        public double Amount { get; set; } 
        public double? PaidAmount { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int FlatId { get; set; }
        [ForeignKey("FlatId")]
        public Flat Flat { get; set; }

        
    }
}
