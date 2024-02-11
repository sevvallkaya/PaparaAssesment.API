using AutoMapper;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;
using PaparaAssesment.API.Models.Types;

namespace PaparaAssesment.API.Models.Payments
{
    public class PaymentService(IPaymentRepository paymentRepository, IMapper mapper) : IPaymentService
    {
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

            paymentRepository.AddPayment(payment);

            return ResponseDto<int>.Success(payment.PaymentId);
        }

        public ResponseDto<int> UpdatePayment(UpdatePaymentDtoRequest request)
        {
            var existingPayment = paymentRepository.GetPaymentById(request.PaymentId);

            existingPayment.PaymentType = request.PaymentType;
            existingPayment.PaymentDate = request.Date;
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

        public PaymentDto GetPaymentByFlatId(int flatId)
        {
            var payment = paymentRepository.GetPaymentByFlatId(flatId);
            return _mapper.Map<PaymentDto>(payment);
        }

        public ResponseDto<int> PayPayment(int paymentId)
        {
            var existingPayment = paymentRepository.GetPaymentById(paymentId);

            existingPayment.IsPaid = true;
            existingPayment.PaymentDate = DateTime.Now;
            existingPayment.PaidAmount = existingPayment.Amount; 

            if (existingPayment.PaymentDate > existingPayment.CreatedDate.AddDays(30))
            {
                existingPayment.PaidAmount += existingPayment.PaidAmount * 0.1;
            }



            paymentRepository.UpdatePayment(existingPayment);

            return ResponseDto<int>.Success(existingPayment.PaymentId);
        }

        public List<PaymentDto> GetPaymentsByResidentId(int residentId)
        {
            var list = paymentRepository.GetPaymentsByResidentId(residentId);
            return list.Select(a=>new PaymentDto()
            {
                   Amount = a.Amount,
                   CreateDate = a.CreatedDate,
                   IsPaid = a.IsPaid,
                   Month = a.Month,
                   PaymentId = a.PaymentId,
                   PaymentType = a.PaymentType,
                   Year = a.Year,
            }).ToList();

        }
    }
}
