namespace PaparaAssesment.API.Models.DTOs
{
    public class AddFlatDtoRequest
    {
        public int FlatId { get; set; }

        public string Block { get; set; } = default!;

        public bool IsAvailable { get; set; }

        public string Type { get; set; } = default!;

        public int Floor { get; set; }

        public int FlatNumber { get; set; }

    }
}
