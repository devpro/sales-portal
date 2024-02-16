namespace Devpro.SalesPortal.CrmAdapterWebApi
{
    public class ApplicationConfiguration(IConfigurationRoot configurationRoot)
        : WebApiConfiguration(configurationRoot)
    {
        public string CrmDataWebApiUrl => TryGetSection("CrmDataWebApi:Url").Get<string>() ?? string.Empty;
    }
}
