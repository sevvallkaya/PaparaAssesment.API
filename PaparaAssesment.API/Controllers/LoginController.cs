using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Residents;

namespace PaparaAssesment.API.Controllers
{
    public class LoginController(IResidentService residentService) : ControllerBase
    {
        private readonly IResidentService _residentService = residentService;
        [HttpPost]
        public IActionResult Login(LoginDtoRequest request)
        {
            var result = _residentService.Login(request.TcNo, request.Phone);
            return Created("", result);
        }
    }
}
