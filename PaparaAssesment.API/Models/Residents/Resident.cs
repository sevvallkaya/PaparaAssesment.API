using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PaparaAssesment.API.Models.Residents
{
    public class Resident : IdentityUser<int>
    {
        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string TcNo { get; set; } = default!;

        public Flat? Flat { get; set; }

    }
}
