using PaparaAssesment.API.Models.Payments;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaAssesment.API.Models.DTOs
{
    public class FlatDto
    {
        public FlatDto()
        {
            Payments = new ();
        }
        public int FlatId { get; set; }

        public string Block { get; set; } = default!;

        public bool IsAvailable { get; set; }

        public string FlatType { get; set; } = default!;

        public int Floor { get; set; }

        public int FlatNumber { get; set; }

        public List<PaymentDto> Payments { get; set; }
    }
}
