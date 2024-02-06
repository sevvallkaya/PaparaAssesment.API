using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Flats
{
    public interface IFlatService
    {
        ResponseDto<List<FlatDto>> GetAllFlats();
        FlatDto GetFlatById(int id);
        ResponseDto<int> AddFlat(AddFlatDtoRequest request);
        ResponseDto<int> UpdateFlat(UpdateFlatDtoRequest request);
        void DeleteFlat(int id);
        FlatDto GetFlatByResidentId(int residentId);
    }
}
