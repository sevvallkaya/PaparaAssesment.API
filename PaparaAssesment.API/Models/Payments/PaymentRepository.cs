using Microsoft.EntityFrameworkCore;
using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Types;

namespace PaparaAssesment.API.Models.Payments
{
    public class PaymentRepository(AppDbContext context) : IPaymentRepository
    {

        public List<Payment> GetAllPayments()
        {
            return context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return context.Payments.Find(id);
        }

        public Payment AddPayment(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment;
        }

        public void UpdatePayment(Payment payment)
        {
            context.Payments.Update(payment);
            context.SaveChanges();
        }

        public void DeletePayment(int id)
        {
            var payment = context.Payments.Find(id);
            context.Remove(payment!);
            context.SaveChanges();
        }

        public Payment GetPaymentByFlatId(int flatId)
        {
            return context.Payments.Where(payment => payment.FlatId == flatId).FirstOrDefault();
        }

        public List<Payment> GetPaymentsByResidentId(int residentId)
        {
            return context.Payments
                .Include(a=>a.Flat)
                .Include(a=>a.PaymentType)
                    .Where(payment => payment.Flat.ResidentId == residentId).ToList();
        }

    }
}
