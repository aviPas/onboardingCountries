namespace OnBoardingCountriesBE.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",//"AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:5230")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });


            });

            return services;
        }




    }
}
