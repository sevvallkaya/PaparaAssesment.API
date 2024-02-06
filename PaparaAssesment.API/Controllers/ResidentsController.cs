using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Residents;

namespace PaparaAssesment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResidentsController(IResidentService residentService) : ControllerBase
    {
        private readonly IResidentService _residentService = residentService;

        [HttpGet]
        public IActionResult GetAllResidents()
        {
            return Ok(residentService.GetAllResidents());
        }

        [HttpGet("{id}")]
        public IActionResult GetResidentById(int id)
        {
            return Ok(residentService.GetResidentById(id));
        }

        [HttpPost]
        public IActionResult AddResident(AddResidentDtoRequest request)
        {
            var result = residentService.AddResident(request);
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(UpdateResidentDtoRequest request)
        {
            residentService.UpdateResident(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResident(int id)
        {
            residentService.DeleteResident(id);
            return NoContent();
        }
    };
}
