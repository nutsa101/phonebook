using AutoMapper;

namespace PhoneBook.Services.Extensions
{
    public static class MapperExtensions
    {
        public static TX MapGeneric<TX, TY>(this TY data)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TY, TX>());
            var mapper = config.CreateMapper();
            return mapper.Map<TY, TX>(data);
        }
    }
}
