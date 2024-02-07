namespace PaparaAssesment.API.Models.DTOs
{
    public class AddFlatDtoRequest
    {

        public int BlockId { get; set; } = default!;

        public bool IsAvailable { get; set; }

        public int FlatTypeId { get; set; } = default!;

        public int Floor { get; set; }

        public int FlatNumber { get; set; }

    }
}
