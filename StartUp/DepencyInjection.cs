

using NUnit.Core.Concrats.Services;
using NUnit.Core.Services;

namespace NUnit.Api.StartUp
{
    public static class DepencyInjection
    {
        public static void AddDepencyInjection(this IServiceCollection services)
        {
            // AddScoped
            services.AddScoped<IHttpClientViaCEPService, HttpClientViaCEPService>();
        }
    }
}
