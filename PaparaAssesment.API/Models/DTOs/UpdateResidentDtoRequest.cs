namespace PaparaAssesment.API.Models.DTOs
{
    public class UpdateResidentDtoRequest
    {
        public int ResidentId { get; set; }

        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TcNo { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public int FlatNumber { get; set; }
    }
}
