using Microsoft.EntityFrameworkCore;

namespace PaparaAssesment.API.Models.Residents
{
    public class ResidentRepositoryWithSqlServer(AppDbContext context) : IResidentRepository
    {
        private readonly AppDbContext _context = context;

        public List<Resident> GetAllResidents()
        {
            return _context.Residents.ToList();
        }

        public Resident? GetResidentById(int id)
        {
            return _context.Residents.Include(a=>a.Flat).FirstOrDefault(a=>a.ResidentId == id);
        }

        public Resident AddResident(Resident resident)
        {
            _context.Residents.Add(resident);
            _context.SaveChanges();
            return resident;
        }

        public void UpdateResident(Resident resident)
        {
            _context.Residents.Update(resident);
            _context.SaveChanges();

        }

        public void DeleteResident(int id)
        {
            var resident = _context.Residents.Find(id);

            _context.Remove(resident!);
            _context.SaveChanges();

        }

        public Resident? Login(string tcNo, string phone)
        {
            var resident = _context.Residents.FirstOrDefault(a=>a.TcNo == tcNo && a.Phone == phone);

            return resident;
        }

    }
}
