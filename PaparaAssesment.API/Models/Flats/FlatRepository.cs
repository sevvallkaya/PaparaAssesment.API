using Microsoft.EntityFrameworkCore;

namespace PaparaAssesment.API.Models.Flats
{
    public class FlatRepository(AppDbContext context) : IFlatRepository
    {
        private readonly AppDbContext _context = context;


        public List<Flat> GetAllFlats()
        {
            return _context.Flats
                .Include(a=>a.Payments)
                .ThenInclude(a=>a.PaymentType)
                .Include(a=>a.Block)
                .Include(a=>a.FlatType)
                .ToList();
        }

        public Flat? GetFlatById(int id)
        {
            return _context.Flats.Find(id);
        }

        public Flat AddFlat(Flat flat)
        {
            _context.Flats.Add(flat);
            _context.SaveChanges();
            return flat;
        }

        public void UpdateFlat(Flat flat)
        {
            _context.Flats.Update(flat);
            _context.SaveChanges();

        }

        public void DeleteFlat(int id)
        {
            var flat = _context.Flats.Find(id);

            _context.Remove(flat!);
            _context.SaveChanges();

        }
        public Flat? GetFlatByResidentId(int residentId)
        {
            return _context.Flats.Where(flat => flat.ResidentId == residentId).FirstOrDefault();
        }

    }
}
