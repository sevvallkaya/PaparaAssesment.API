using Microsoft.IdentityModel.Tokens;
using PaparaAssesment.API.Models.DTOs;
using PaparaAssesment.API.Models.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PaparaAssesment.API.Models.Residents;
using System.Collections.Generic;

namespace PaparaAssesment.API.Models.Token
{
    public class TokenService(IConfiguration configuration, UserManager<Resident> userManager, IResidentService residentService)
    {
        public async Task<ResponseDto<TokenCreateDtoResponse>> Create(TokenCreateDtoRequest request)
        {

            var hasResident = residentService.Login(request.TcNo, request.Phone);

         //   var checkPhone = await userManager.CheckPasswordAsync(hasResident!, request.Phone);

            if (hasResident == null )
            {
                return ResponseDto<TokenCreateDtoResponse>.Fail("Kimlik numarası veya telefon numarası hatalı");
            }




            var signatureKey = configuration.GetSection("TokenOptions")!["SignatureKey"]!;
            var tokenExpiration = configuration.GetSection("TokenOptions")!["TokenExpiration"]!;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey));


            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimList = new List<Claim>();

            var residentIdAsClaim = new Claim(ClaimTypes.NameIdentifier, hasResident.Id.ToString());
            var tcNoAsClaim = new Claim(ClaimTypes.Name, hasResident.TcNo);
            var idAsClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());


            claimList.Add(residentIdAsClaim);
            claimList.Add(tcNoAsClaim);
            claimList.Add(idAsClaim);


            foreach (var role in await userManager.GetRolesAsync(hasResident))
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(Convert.ToDouble(tokenExpiration)),
                signingCredentials: signingCredentials, claims: claimList
                );

            var responseDto = new TokenCreateDtoResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return ResponseDto<TokenCreateDtoResponse>.Success(responseDto);

            
            
        }
    }
}
