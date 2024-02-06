using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Residents
{
    public interface IResidentService
    {

        ResponseDto<List<ResidentDto>> GetAllResidents();
        ResidentDto GetResidentById(int id);
        ResponseDto<int> AddResident(AddResidentDtoRequest request);
        ResponseDto<int> UpdateResident(UpdateResidentDtoRequest request);
        void DeleteResident(int id);
        
    }
}
