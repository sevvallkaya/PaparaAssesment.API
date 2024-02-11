using AutoMapper;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Payments;
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
            var flatList = _flatRepository.GetAllFlats();

            var data = flatList.Select(flat => new FlatDto
            {
                Block = flat.Block.Name,
                IsAvailable = flat.IsAvailable,
                FlatType = flat.FlatType.Type,
                Floor = flat.Floor,
                FlatNumber = flat.FlatNumber,
                FlatId = flat.FlatId,
                Payments = flat.Payments.Select(a=>new PaymentDto()
                {
                     Amount = a.Amount,
                      CreateDate = a.CreatedDate,
                      IsPaid = a.IsPaid,
                            Month = a.Month,
                             PaymentId = a.PaymentId,
                              PaymentType = a.PaymentType,
                            Year = a.Year
                }).ToList()
            }).ToList();
            
            //var flatListWithDto = _mapper.Map<List<FlatDto>>(flatList);

            return ResponseDto<List<FlatDto>>.Success(data);
        }

        public FlatDto GetFlatById(int id)
        {
            var flat = _flatRepository.GetFlatById(id);
            return _mapper.Map<FlatDto>(flat);
        }

        public ResponseDto<int> AddFlat(AddFlatDtoRequest request)
        {
            var flat = new Flat
            {
                BlockId = request.BlockId,
                IsAvailable = request.IsAvailable,
                FlatTypeId = request.FlatTypeId,
                Floor = request.Floor,
                FlatNumber = request.FlatNumber
            };

            _flatRepository.AddFlat(flat);

            return ResponseDto<int>.Success(flat.FlatId);
        }

        public ResponseDto<int> UpdateFlat(UpdateFlatDtoRequest request)
        {
            var existingFlat = _flatRepository.GetFlatById(request.FlatId);
            if (existingFlat == null)
            {
                return ResponseDto<int>.Fail("Flat not found");
            }

            existingFlat.BlockId = request.BlockId;
            existingFlat.IsAvailable = request.IsAvailable;
            existingFlat.FlatTypeId = request.FlatTypeId;
            existingFlat.Floor = request.Floor;
            existingFlat.FlatNumber = request.FlatNumber;

            _flatRepository.UpdateFlat(existingFlat);

            return ResponseDto<int>.Success(existingFlat.FlatId);

        }

        public void DeleteFlat(int id)
        {
            _flatRepository.DeleteFlat(id);
        }

        public FlatDto GetFlatByResidentId(int residentId)
        {
            var flats = _flatRepository.GetFlatByResidentId(residentId);
            return _mapper.Map<FlatDto>(flats);
        }


        public void SetResidentToFlat(int residentId, int flatId)
        {
            var flat = _flatRepository.GetFlatById(flatId);

            flat.ResidentId = residentId;
            _flatRepository.UpdateFlat(flat);
        }

        public void RemoveResidentFromFlat(int flatId)
        {
            var flat = _flatRepository.GetFlatById(flatId);

            flat.ResidentId = null;
            _flatRepository.UpdateFlat(flat);
        }

    }
}
