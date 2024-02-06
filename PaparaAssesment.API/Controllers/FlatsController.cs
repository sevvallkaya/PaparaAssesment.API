using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.Flats;

namespace PaparaAssesment.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FlatsController(IFlatService flatService) : ControllerBase
    {
        private readonly IFlatService _flatService = flatService;

        [HttpGet]
        public IActionResult GetAllFlats()
        {
            return Ok(_flatService.GetAllFlats());
        }

        [HttpGet("{id}")]
        public IActionResult GetFlatById(int id)
        {
            return Ok(_flatService.GetFlatById(id));
        }

        [HttpGet("resident/{residentId}")]
        public IActionResult GetFlatByResidentId(int residentId)
        {
            return Ok(_flatService.GetFlatByResidentId(residentId));
        }
    }       
    
}
