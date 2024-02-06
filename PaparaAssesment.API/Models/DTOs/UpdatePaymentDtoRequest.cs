using PaparaAssesment.API.Models.Payments;

namespace PaparaAssesment.API.Models.DTOs
{
    public class UpdatePaymentDtoRequest
    {
        public int PaymentId { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; } = default!;

        public double Amount { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
