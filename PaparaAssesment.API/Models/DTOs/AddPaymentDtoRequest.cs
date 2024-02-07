using PaparaAssesment.API.Models.Types;

namespace PaparaAssesment.API.Models.DTOs
{
    public class AddPaymentDtoRequest
    {
        public int PaymentTypeId { get; set; }

        public double Amount { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int FlatId { get; set; }
    }
}
