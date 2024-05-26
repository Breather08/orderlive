namespace Orderlive.UI
{
    public static class ConfigService
    {
        public static void AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("OpenAI", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("HttpClients").GetSection("OpenAI")["BaseAddress"]);
                client.DefaultRequestHeaders.Add("Authorization", configuration.GetSection("Secrets")["ApiKey"]);
            });
        }
    }
}
