using Microsoft.AspNetCore.Mvc;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Payments;

namespace PaparaAssesment.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
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

        [HttpGet("{flatId}")]
        public IActionResult GetPaymentByFlatId(int flatId)
        {
            return Ok(paymentService.GetPaymentByFlatId(flatId));
        }

        [HttpPost]
        public IActionResult AddPaymentByManager(AddPaymentDtoRequest request)
        {
            var result = paymentService.AddPaymentByManager(request);
            return Created("", result);
        }

        [HttpPost]
        public IActionResult UpdatePayment(UpdatePaymentDtoRequest request)
        {
            paymentService.UpdatePayment(request);
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult DeletePayment(int id)
        {
            paymentService.DeletePayment(id);
            return NoContent();
        }

    }
}
