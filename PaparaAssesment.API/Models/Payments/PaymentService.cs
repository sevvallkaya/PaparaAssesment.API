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
            var paymentList = _paymentRepository.GetAllPayments();
            var paymentListWithDto = _mapper.Map<List<PaymentDto>>(paymentList);
            return ResponseDto<List<PaymentDto>>.Success(paymentListWithDto);
        }

        public PaymentDto GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public ResponseDto<int> AddPaymentByManager(AddPaymentDtoRequest request)
        {
            var payment = new Payment
            {
                PaymentTypeId = request.PaymentTypeId,
                CreatedDate = DateTime.Now,
                Amount = request.Amount,
                IsPaid = false,
                Year = request.Year,
                Month = request.Month,
                FlatId = request.FlatId
            };

            _paymentRepository.AddPayment(payment);

            return ResponseDto<int>.Success(payment.PaymentId);
        }

        public ResponseDto<int> UpdatePayment(UpdatePaymentDtoRequest request)
        {
            var existingPayment = _paymentRepository.GetPaymentById(request.PaymentId);

            existingPayment.PaymentType = request.PaymentType;
            existingPayment.PaymentDate = request.Date;
            existingPayment.Amount = request.Amount;
            existingPayment.Year = request.Year;
            existingPayment.Month = request.Month;

            _paymentRepository.UpdatePayment(existingPayment);

            return ResponseDto<int>.Success(existingPayment.PaymentId);
        }

        public ResponseDto<int> DeletePayment(int id)
        {
            _paymentRepository.DeletePayment(id);
            return ResponseDto<int>.Success(id);
        }

        public PaymentDto GetPaymentByFlatId(int flatId)
        {
            var payment = _paymentRepository.GetPaymentByFlatId(flatId);
            return _mapper.Map<PaymentDto>(payment);
        }

    }
}
