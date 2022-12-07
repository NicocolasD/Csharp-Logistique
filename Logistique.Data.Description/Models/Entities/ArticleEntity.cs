using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class ArticleEntity : EntityBase<int>
{
    public string Ean {get;set;}
    public string Description{get;set;}
    public string PartNo {get;set;}
}