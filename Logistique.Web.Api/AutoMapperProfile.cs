using AutoMapper;
using Logistique.Business.Description.BusinessModel;
using Logistique.Data.Description.Models.Entities;
using DeliveryStateBusiness = Logistique.Business.Description.BusinessModel.DeliveryState;
using DeliveryStateEntity = Logistique.Data.Description.Models.Entities.DeliveryState;

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
        CreateMap<DeliveryStateBusiness, DeliveryStateEntity>(); 
        CreateMap<DeliveryStateEntity, DeliveryStateBusiness>();
        CreateMap<StockTransactionHistory, StockTransactionHistoryEntity>();
        CreateMap<StockTransactionHistoryEntity, StockTransactionHistory>();
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();
    }
}