using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaAssesment.API.Models.Residents
{
    public class Resident
    {
        [Key]
        public int ResidentId { get; set; }
        
        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TcNo { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public Flat? Flat { get; set; }

    }
}
