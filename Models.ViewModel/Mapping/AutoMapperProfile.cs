
using AutoMapper;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        private HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public Language GetUserLangId()
        {
            StringValues langs;
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("lang", out langs);
            var lang = langs.FirstOrDefault();
            return string.IsNullOrEmpty(lang) ? Language.English : lang == "en" ? Language.English : Language.Arabic;
        }
        public string Gethost()
        {
            var host = _httpContextAccessor.HttpContext.Request.Host.Host;
            return host;
        }
        public int? GetPort()
        {
            var port = _httpContextAccessor.HttpContext.Request.Host.Port;
            return port;
        }

        public AutoMapperProfile()
        {

            FaqsMappingProfile();
            UserMappingProfile();
            AboutMappingProfile();
            RequestsMappingProfile();
            SlidersMappingProfile();
            CategoryMappingProfile();
            ProductMappingProfile();
        }
    }
}
