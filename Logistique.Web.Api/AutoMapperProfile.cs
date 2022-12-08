using AutoMapper;
using Logistique.Business.BusinessModel;
using Logistique.Data.Description.Models.Entities;

namespace Logistique.Web.Api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ArticleEntity, Article>();
        CreateMap<Article, ArticleEntity>();
        CreateMap<StockEntity, Stock>();
    }
}