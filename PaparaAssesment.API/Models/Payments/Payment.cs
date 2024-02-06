using PaparaAssesment.API.Models.Residents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaAssesment.API.Models.Payments
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; } = default!;

        public double Amount { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        //DateTime paymentDate = DateTime.Now;
        //int year = paymentDate.Year;
        //int month = paymentDate.Month;

        //public int? ResidentId { get; set; }
        //[ForeignKey("ResidentId")]
        //public Resident? Resident { get; set; }
    }
}
