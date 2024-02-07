using System.ComponentModel.DataAnnotations;

namespace PaparaAssesment.API.Models.Types
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
