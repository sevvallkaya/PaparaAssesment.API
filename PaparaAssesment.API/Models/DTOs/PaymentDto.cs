using PaparaAssesment.API.Models.Types;

namespace PaparaAssesment.API.Models.DTOs
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime CreateDate { get; set; }

        public double Amount { get; set; }
        public double ? PaidAmount { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
        public bool IsPaid { get; set; }
    }
}
