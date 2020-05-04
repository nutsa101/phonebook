using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Repository.Contracts;

namespace PhoneBook.Repository.DI
{
    public static class RepositoryModule
    {
        public static void ConfigureRepositoryModule(this IServiceCollection services)
        {
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
        }
    }
}
