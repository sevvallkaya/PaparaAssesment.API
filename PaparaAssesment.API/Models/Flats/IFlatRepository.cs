using PaparaAssesment.API.Models.DTOs;

namespace PaparaAssesment.API.Models.Flats
{
    public interface IFlatRepository
    {
        List<Flat> GetAllFlats();
        Flat? GetFlatById(int id);
        Flat AddFlat(Flat flat);
        void UpdateFlat(Flat flat);
        void DeleteFlat(int id);
        Flat? GetFlatByResidentId(int residentId);


    }
}
