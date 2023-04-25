using Microsoft.Extensions.DependencyInjection;
using NUnit.Core.Concrats;
using NUnit.Core.Config;
using Refit;

namespace Nunit.Api.StartUp
{
    public static class RefitStartUp
    {
        public static void AddRefit(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var appConfig = serviceProvider?.GetService<IConfiguration>()?.GetSection("AppConfig").Get<AppConfig>();

            services.AddRefitClient<IHttpClientCEP>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(appConfig.ApiUrl));
        }
    }
}
