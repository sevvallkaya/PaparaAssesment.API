namespace PaparaAssesment.API.Models.Payments
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        Payment AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
        Payment GetPaymentByFlatId(int flatId);
    }
}
