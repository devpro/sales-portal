using Devpro.Common.DataModel;

namespace Devpro.SalesPortal.SalesDomain.Dtos
{
    public class OpportunityDto : IDto
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
