using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Flats;

namespace PaparaAssesment.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class FlatsController(IFlatService flatService) : ControllerBase
    {
        private readonly IFlatService _flatService = flatService;

        [HttpGet]
        public IActionResult GetAllFlats()
        {
            return Ok(flatService.GetAllFlats());
        }

        [HttpGet("{id}")]
        public IActionResult GetFlatById(int id)
        {
            return Ok(flatService.GetFlatById(id));
        }

        [HttpGet("{residentId}")]
        public IActionResult GetFlatByResidentId(int residentId)
        {
            return Ok(flatService.GetFlatByResidentId(residentId));
        }

        [HttpPost]

        [HttpPost]
        public IActionResult AddFlat(AddFlatDtoRequest request)
        {
            var result = flatService.AddFlat(request);
            return Created("", result);
        }

        [HttpPost]
        public IActionResult UpdateFlat(UpdateFlatDtoRequest request)
        {
            flatService.UpdateFlat(request);
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult DeleteFlat(int id)
        {
            flatService.DeleteFlat(id);
            return NoContent();
        }

        

    }       
    
}
