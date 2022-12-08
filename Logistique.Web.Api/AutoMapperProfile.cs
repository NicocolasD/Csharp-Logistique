using AutoMapper;
using Logistique.Business.BusinessModel;
using Logistique.Data.Description.Models.Entities;

namespace Logistique.Web.Api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PartEntity, Part>();
        CreateMap<Part, PartEntity>();
        CreateMap<StockEntity, Stock>();
        CreateMap<Stock, StockEntity>();
        CreateMap<DeliveryEntity, Delivery>();
        CreateMap<Delivery, DeliveryEntity>();
        CreateMap<DeliveryLineEntity, DeliveryLine>();
        CreateMap<DeliveryLine, DeliveryLineEntity>();
    }
}