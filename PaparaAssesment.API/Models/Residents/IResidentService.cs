using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Residents
{
    public interface IResidentService
    {
        Task<ResponseDto<int>> CreateUser(ResidentCreateDtoRequest request);
        Task<ResponseDto<string>> CreateRole(ResidentRoleCreateDtoRequest request);
        Task<ResponseDto<List<ResidentDto>>> GetAllResidents();
        Task<ResponseDto<ResidentDto>> GetResidentById(int residentId);
        Task<ResponseDto<int>> UpdateResident(ResidentUpdateDtoRequest request);
        Task<ResponseDto<int>> DeleteResident(int residentId);
        Resident? Login(string tcNo, string phone);


    }
}
