using OnboardingCountriesDAL.Services;

namespace OnBoardingCountriesBE.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    public static class FilldbExtention
    {

        
            public static void AddApiService(this IServiceCollection services, IConfiguration configuration)
            {
               
                services.AddSingleton<IFilldbFromApiService,FilldbFromApiService>();
            }
        public static async void HandleFillMongoDBData(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var apiService = serviceProvider.GetRequiredService<IFilldbFromApiService>();
                await apiService.HandleMongoDBData();
            }
        }




    }
}
