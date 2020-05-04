using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Services.Contracts;

namespace PhoneBook.Services.DI
{
    public static class ServiceModule
    {
        public static void ConfigureServiceModule(this IServiceCollection services)
        {
            services.AddScoped<IPhoneBookService, PhoneBookService>();
        }
    }
}
