namespace PaparaAssesment.API.Models.Payments
{
    public class PaymentRepository(AppDbContext context) : IPaymentRepository
    {
        private readonly AppDbContext _context = context;

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _context.Payments.Find(id);
        }

        public Payment AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }

        public void DeletePayment(int id)
        {
            var payment = _context.Payments.Find(id);
            _context.Remove(payment!);
            _context.SaveChanges();
        }
        
    }
}
