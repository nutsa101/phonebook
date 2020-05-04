using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Api.Filter;

namespace PhoneBook.Api.DI
{
    public static class ApiModule
    {
        public static void ConfigureApiModule(this IServiceCollection services)
        {
            services.AddScoped<AuthorizationFilter>();
            services.AddScoped<ExceptionFilter>();
        }
    }
}
