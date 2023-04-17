namespace Devpro.SalesPortal.CrmAdapterWebApi
{
    public class ApplicationConfiguration : WebApiConfiguration
    {
        public ApplicationConfiguration(IConfigurationRoot configurationRoot)
            : base(configurationRoot)
        {
        }

        public string CrmDataWebApiUrl => TryGetSection("CrmDataWebApi:Url").Get<string>() ?? string.Empty;
    }
}
