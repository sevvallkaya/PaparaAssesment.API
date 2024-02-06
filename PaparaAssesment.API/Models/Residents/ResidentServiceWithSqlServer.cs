using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Residents
{
    public class ResidentServiceWithSqlServer(IResidentRepository residentRepository,IMapper mapper) : IResidentService
    {
        private IResidentRepository _residentRepository = residentRepository;
        private IMapper _mapper = mapper;

        public ResponseDto<List<ResidentDto>> GetAllResidents()
        {

            var residentList = residentRepository.GetAllResidents();


            foreach (var resident in residentList)
            {
                //var flat = GetFlatByResidentId(resident.Id);
                //resident.Flat = flat;
            }   

            var residentListWithDto = _mapper.Map<List<ResidentDto>>(residentList);


            return ResponseDto<List<ResidentDto>>.Success(residentListWithDto);
        }

        public ResidentDto GetResidentById(int id)
        {
            var resident = residentRepository.GetResidentById(id);
            //var flat = getFlatByResidentId(resident.Id);
            //resident.Flat = flat;

            return _mapper.Map<ResidentDto>(resident);
        }


        public ResponseDto<int> AddResident(AddResidentDtoRequest request)
        {

            var resident = new Resident
            {
                Name = request.Name,
                Surname = request.Surname,
                TcNo = request.TcNo,
                Email = request.Email,
                Phone = request.Phone

            };

            residentRepository.AddResident(resident);

            return ResponseDto<int>.Success(resident.ResidentId);
        }

        public ResponseDto<int> UpdateResident(UpdateResidentDtoRequest request)
        {
            var existingResident = _residentRepository.GetResidentById(request.ResidentId);

            if (existingResident == null)
            {
                return ResponseDto<int>.Fail("Güncellenen sakini bulma başarısız.");
            }

            existingResident.Name = request.Name;
            existingResident.Surname = request.Surname;
            existingResident.TcNo = request.TcNo;
            existingResident.Email = request.Email;
            existingResident.Phone = request.Phone;

            residentRepository.UpdateResident(existingResident);

            return ResponseDto<int>.Success(existingResident.ResidentId);
        }


        

        public void DeleteResident(int id)
        {
            var resident = residentRepository.GetResidentById(id);

            if (resident == null)
            {
                throw new Exception("Sakini bulma başarısız.");
            }

            //RemoveResidentToFlat(resident.Id, resident.Flat.Id);

            residentRepository.DeleteResident(id);
        }

        //SetResidentToFlat(residentId, flatId)
        //RemoveResidentToFlat(residentId, flatId)
    }
}
