using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Payments;

namespace PaparaAssesment.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            return Ok(paymentService.GetAllPayments());
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            return Ok(paymentService.GetPaymentById(id));
        }

        [HttpPost("add")]
        public IActionResult AddPayment(AddPaymentDtoRequest request)
        {
            var result = paymentService.AddPayment(request);
            return Created("", result);
        }

        [HttpPost("update")]
        public IActionResult UpdatePayment(UpdatePaymentDtoRequest request)
        {
            paymentService.UpdatePayment(request);
            return NoContent();
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeletePayment(int id)
        {
            paymentService.DeletePayment(id);
            return NoContent();
        }

    }
}
