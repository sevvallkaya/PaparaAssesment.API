using AutoMapper;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Residents;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Flats
{
    public class FlatService(IFlatRepository flatRepository, IMapper mapper) : IFlatService
    {

        private IFlatRepository _flatRepository = flatRepository;
        private IMapper _mapper = mapper;


        public ResponseDto<List<FlatDto>> GetAllFlats()
        {
            var flatList = flatRepository.GetAllFlats();
            
            var flatListWithDto = _mapper.Map<List<FlatDto>>(flatList);

            return ResponseDto<List<FlatDto>>.Success(flatListWithDto);
        }

        public FlatDto GetFlatById(int id)
        {
            var flat = flatRepository.GetFlatById(id);
            return _mapper.Map<FlatDto>(flat);
        }

        public ResponseDto<int> AddFlat(AddFlatDtoRequest request)
        {
            var flat = new Flat
            {
                Block = request.Block,
                IsAvailable = request.IsAvailable,
                Type = request.Type,
                Floor = request.Floor,
                FlatNumber = request.FlatNumber
            };

            flatRepository.AddFlat(flat);

            return ResponseDto<int>.Success(flat.FlatId);
        }

        public ResponseDto<int> UpdateFlat(UpdateFlatDtoRequest request)
        {
            var existingFlat = flatRepository.GetFlatById(request.FlatId);

            existingFlat.Block = request.Block;
            existingFlat.IsAvailable = request.IsAvailable;
            existingFlat.Type = request.Type;
            existingFlat.Floor = request.Floor;
            existingFlat.FlatNumber = request.FlatNumber;

            flatRepository.UpdateFlat(existingFlat);

            return ResponseDto<int>.Success(existingFlat.FlatId);

        }

        public void DeleteFlat(int id)
        {
            var flat = flatRepository.GetFlatById(id);
            flatRepository.DeleteFlat(id);
        }

        public FlatDto GetFlatByResidentId(int residentId)
        {
            var flats = flatRepository.GetFlatByResidentId(residentId);
            return _mapper.Map<FlatDto>(flats);
        }


    }
}
