using System.ComponentModel.DataAnnotations;

namespace PaparaAssesment.API.Models.DTOs
{
    public class AddResidentDtoRequest
    {
        public int ResidentId { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez!")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Soyisim alanı boş geçilemez!")]
        public string Surname { get; set; } = default!;


        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçersiz TC Kimlik Numarası.")]
        public string TcNo { get; set; } = default!;

        [EmailAddress(ErrorMessage = "Geçersiz e-mail adresi.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Telefon numarası boş geçilemez!")]
        public string Phone { get; set; } = default!;


        public int FlatNumber { get; set; }
    }
}
