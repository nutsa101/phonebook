using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.Data.DI
{
    public static class DataModule
    {
        public static void ConfigureDataModule(this IServiceCollection services)
        {
            services.AddDbContext<PhoneBookDataContext>();
        }
    }
}
