namespace PaparaAssesment.API.Models.DTOs
{
    public class ResidentRoleCreateDtoRequest
    {
        public string ResidentId { get; set; } = default!;

        public string RoleName { get; set; } = default!;
    }
}
