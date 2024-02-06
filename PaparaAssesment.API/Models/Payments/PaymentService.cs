using AutoMapper;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Payments
{
    public class PaymentService(IPaymentRepository paymentRepository, IMapper mapper) : IPaymentService
    {
        private IPaymentRepository _paymentRepository = paymentRepository;
        private IMapper _mapper = mapper;

        public ResponseDto<List<PaymentDto>> GetAllPayments()
        {
            var paymentList = paymentRepository.GetAllPayments();
            var paymentListWithDto = _mapper.Map<List<PaymentDto>>(paymentList);
            return ResponseDto<List<PaymentDto>>.Success(paymentListWithDto);
        }

        public PaymentDto GetPaymentById(int id)
        {
            var payment = paymentRepository.GetPaymentById(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public ResponseDto<int> AddPayment(AddPaymentDtoRequest request)
        {
            var payment = new Payment
            {
                PaymentType = request.PaymentType,
                Date = request.Date,
                Category = request.Category,
                Amount = request.Amount,
                Year = request.Year,
                Month = request.Month
            };

            paymentRepository.AddPayment(payment);

            return ResponseDto<int>.Success(payment.PaymentId);
        }

        public ResponseDto<int> UpdatePayment(UpdatePaymentDtoRequest request)
        {
            var existingPayment = paymentRepository.GetPaymentById(request.PaymentId);

            existingPayment.PaymentType = request.PaymentType;
            existingPayment.Date = request.Date;
            existingPayment.Category = request.Category;
            existingPayment.Amount = request.Amount;
            existingPayment.Year = request.Year;
            existingPayment.Month = request.Month;

            paymentRepository.UpdatePayment(existingPayment);

            return ResponseDto<int>.Success(existingPayment.PaymentId);
        }

        public ResponseDto<int> DeletePayment(int id)
        {
            paymentRepository.DeletePayment(id);
            return ResponseDto<int>.Success(id);
        }

    }
}
