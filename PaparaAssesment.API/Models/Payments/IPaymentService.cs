﻿using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Payments
{
    public interface IPaymentService
    {
        ResponseDto<List<PaymentDto>> GetAllPayments();
        PaymentDto GetPaymentById(int id);
        ResponseDto<int> AddPayment(AddPaymentDtoRequest request);
        ResponseDto<int> UpdatePayment(UpdatePaymentDtoRequest request);
        ResponseDto<int> DeletePayment(int id);
    }
}