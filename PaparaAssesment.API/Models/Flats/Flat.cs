using PaparaAssesment.API.Models.Payments;
using PaparaAssesment.API.Models.Residents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaAssesment.API.Models.Flats
{
    public class Flat
    {
        [Key]
        public int FlatId { get; set; }

        public string Block { get; set; } = default!;

        public bool IsAvailable { get; set; }

        public string Type { get; set; } = default!;

        public int Floor { get; set; }

        public int FlatNumber { get; set; }

        


        public int? PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public List<Payment>? Payments { get; set; }

        public int? ResidentId { get; set; }
        [ForeignKey("ResidentId")]
        public Resident? Resident { get; set; }
        
        
    }
}
