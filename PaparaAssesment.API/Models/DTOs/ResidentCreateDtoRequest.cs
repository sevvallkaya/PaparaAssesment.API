namespace PaparaAssesment.API.Models.DTOs
{
    public class ResidentCreateDtoRequest

    {
        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TcNo { get; set; } = default!;

        public string Phone { get; set; } = default!;
    }
}
