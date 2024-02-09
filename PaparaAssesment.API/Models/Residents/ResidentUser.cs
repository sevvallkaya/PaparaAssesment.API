using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using PaparaAssesment.API.Models.Flats;

namespace PaparaAssesment.API.Models.Residents
{
    public class ResidentUser : IdentityRole<int>
    {
    }
}
