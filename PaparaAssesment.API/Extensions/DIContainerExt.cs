using PaparaAssesment.API.Models.Flats;
using PaparaAssesment.API.Models.Payments;
using PaparaAssesment.API.Models.Residents;
using PaparaAssesment.API.Models.Token;

namespace PaparaAssesment.API.Extensions
{
    public static class DIContainerExt
    {
        public static void AddDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IResidentRepository, ResidentRepositoryWithSqlServer>();
            services.AddScoped<IResidentService, ResidentServiceWithSqlServer>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<TokenService>();

        }


    }
}
