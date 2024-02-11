using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;
using PaparaAssesment.API.Models.Types;

namespace PaparaAssesment.API.Models.Payments
{
    public interface IPaymentService
    {
        ResponseDto<List<PaymentDto>> GetAllPayments();
        PaymentDto GetPaymentById(int id);
        ResponseDto<int> AddPaymentByManager(AddPaymentDtoRequest request);
        ResponseDto<int> UpdatePayment(UpdatePaymentDtoRequest request);
        ResponseDto<int> DeletePayment(int id);
        PaymentDto GetPaymentByFlatId(int flatId);
        ResponseDto<int> PayPayment(int paymentId);
        List<PaymentDto> GetPaymentsByResidentId(int residentId);
    }
}
