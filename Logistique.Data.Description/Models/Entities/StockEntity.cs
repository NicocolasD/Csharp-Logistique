using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class StockEntity : EntityBase<int>
{
    public int Quantity {get;set;}
    [ForeignKey("Article")]
    public int ArticleId {get;set;}
    public ArticleEntity Article {get;set;}
}