using System.ComponentModel.DataAnnotations;

namespace PaparaAssesment.API.Models.Types
{
    public class FlatType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } = default!;
    }
}
