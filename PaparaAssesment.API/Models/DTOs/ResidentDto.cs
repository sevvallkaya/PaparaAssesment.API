namespace PaparaAssesment.API.Models.DTOs
{
    public class ResidentDto
    {
        public int ResidentId { get; set; }

        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TcNo { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public int FlatId { get; set; }
        public int FlatNumber { get; set; }
    }
}
