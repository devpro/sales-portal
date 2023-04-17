using AutoMapper;

namespace Devpro.SalesPortal.CrmDataWebApi.Mapping
{
    internal class CrmDataMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DevproSalesPortalCrmDataMappingProfile"; }
        }

        public CrmDataMappingProfile()
        {
            CreateMap<Entities.Customer, SalesDomain.Dtos.CustomerDto>();
            CreateMap<SalesDomain.Dtos.CustomerDto, Entities.Customer>();

            CreateMap<Entities.Opportunity, SalesDomain.Dtos.OpportunityDto>();
            CreateMap<SalesDomain.Dtos.OpportunityDto, Entities.Opportunity>();
        }
    }
}
