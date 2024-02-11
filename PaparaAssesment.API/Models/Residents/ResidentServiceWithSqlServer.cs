using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Shared;

namespace PaparaAssesment.API.Models.Residents
{
    public class ResidentServiceWithSqlServer(IResidentRepository residentRepository,IMapper mapper, IFlatRepository flatRepository, UserManager<Resident> userManager, RoleManager<ResidentUser> roleManager) : IResidentService
    {

        public async Task<ResponseDto<int>> CreateUser(ResidentCreateDtoRequest request)
        {

            var resident = new Resident
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.Name+request.Surname,
                TcNo = request.TcNo,
                PhoneNumber = request.Phone
            };

            var result = await userManager.CreateAsync(resident);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();
                return ResponseDto<int>.Fail(errorList);
            }

            return ResponseDto<int>.Success(resident.Id);
        }

        public async Task<ResponseDto<string>> CreateRole(ResidentRoleCreateDtoRequest request)
        {
            var residentUser = new ResidentUser
            {
                Name = request.RoleName
            };

            var hasRole = await roleManager.RoleExistsAsync(residentUser.Name);


            IdentityResult? roleCreateResult = null;

            if (!hasRole)
            {
                roleCreateResult = await roleManager.CreateAsync(residentUser);

                
            }

            if (roleCreateResult is not null &&  !roleCreateResult.Succeeded)
            {
                var errorList = roleCreateResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }

            var hasResident = await userManager.FindByIdAsync(request.ResidentId);

            if (hasResident is null)
            {
                return ResponseDto<string>.Fail("Sakin bulma başarısız.");
            }

            var roleAssignResult = await userManager.AddToRoleAsync(hasResident, residentUser.Name);

            if (!roleAssignResult.Succeeded)
            {
                var errorList = roleAssignResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }

            return ResponseDto<string>.Success(string.Empty);
        }

        public async Task<ResponseDto<ResidentDto>> GetResidentById(int residentId)
        {
            var resident = await userManager.FindByIdAsync(residentId.ToString());

            if (resident == null)
            {
                return ResponseDto<ResidentDto>.Fail("Kullanıcı bulunamadı.");
            }
            var residentDto = new ResidentDto
            {
                ResidentId = resident.Id,
            };

            return ResponseDto<ResidentDto>.Success(residentDto);
        }

        public async Task<ResponseDto<int>> UpdateResident(ResidentUpdateDtoRequest request)
        {
            var existingResident = await userManager.FindByIdAsync(request.ResidentId.ToString());

            if (existingResident == null)
            {
                return ResponseDto<int>.Fail("Güncellenmek istenen kullanıcı bulunamadı.");
            }

            existingResident.TcNo = request.TcNo;
            existingResident.PhoneNumber = request.Phone;

            var result = await userManager.UpdateAsync(existingResident);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();
                return ResponseDto<int>.Fail(errorList);
            }

            return ResponseDto<int>.Success(existingResident.Id);
        }

        public async Task<ResponseDto<int>> DeleteResident(int residentId)
        {
            var residentToDelete = await userManager.FindByIdAsync(residentId.ToString());

            if (residentToDelete == null)
            {
                return ResponseDto<int>.Fail("Silinecek kullanıcı bulunamadı.");
            }

            var result = await userManager.DeleteAsync(residentToDelete);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();
                return ResponseDto<int>.Fail(errorList);
            }

            return ResponseDto<int>.Success(residentId);
        }

        public async Task<ResponseDto<List<ResidentDto>>> GetAllResidents()
        {
            var residents = await userManager.Users.ToListAsync();

            if (residents == null || !residents.Any())
            {
                return ResponseDto<List<ResidentDto>>.Success(new List<ResidentDto>());
            }

            var residentDtos = residents.Select(resident => new ResidentDto
            {
                ResidentId = resident.Id,
            }).ToList();

            return ResponseDto<List<ResidentDto>>.Success(residentDtos);
        }


        public Resident? Login(string tcNo, string phone)
        {
            var resident = residentRepository.Login(tcNo, phone);

            return resident;

        }

    }
}
