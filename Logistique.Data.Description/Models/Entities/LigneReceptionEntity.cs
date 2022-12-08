using System.ComponentModel.DataAnnotations;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class LigneReceptionEntity : EntityBase<int>
{
    public virtual ArticleEntity Article {get;set;}
    public int Quantity {get;set;}
}