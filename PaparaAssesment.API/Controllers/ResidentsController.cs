using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Residents;
using PaparaAssesment.API.Models.Token;

namespace PaparaAssesment.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResidentsController(IResidentService residentService, TokenService tokenService) : ControllerBase
    {
        private readonly IResidentService _residentService = residentService;
        private readonly TokenService _tokenService = tokenService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidentById(int id)
        {
            var response = await _residentService.GetResidentById(id);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(TokenCreateDtoRequest request)
        {
            var response = await tokenService.Create(request);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(ResidentCreateDtoRequest request)
        {
            var response = await _residentService.CreateUser(request);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Created("", response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(ResidentRoleCreateDtoRequest request)
        {
            var response = await _residentService.CreateRole(request);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Created("", response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResident(ResidentUpdateDtoRequest request)
        {
            var response = await _residentService.UpdateResident(request);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            var response = await _residentService.DeleteResident(id);

            if (response.AnyError)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        




        [HttpGet]
        public IActionResult GetAllResidents()
        {
            return Ok(residentService.GetAllResidents());
        }

        //[HttpGet("{id}")]
        //public IActionResult GetResidentById(int id)
        //{
        //    return Ok(residentService.GetResidentById(id));
        //}

        //[HttpPost]
        //public IActionResult AddResident(AddResidentDtoRequest request)
        //{
        //    var result = residentService.AddResident(request);
        //    return Created("", result);
        //}

        //[HttpPut]
        //public IActionResult Update(UpdateResidentDtoRequest request)
        //{
        //    residentService.UpdateResident(request);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteResident(int id)
        //{
        //    residentService.DeleteResident(id);
        //    return NoContent();
        //}
    };
}
