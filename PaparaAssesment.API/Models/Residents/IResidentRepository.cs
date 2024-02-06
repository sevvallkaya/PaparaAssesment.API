namespace PaparaAssesment.API.Models.Residents
{
    public interface IResidentRepository
    {
        List<Resident> GetAllResidents();
        Resident? GetResidentById(int id);
        Resident AddResident(Resident resident);
        void UpdateResident(Resident resident);
        void DeleteResident(int id);
    }
}
