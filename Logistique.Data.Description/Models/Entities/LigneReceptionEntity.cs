using System.ComponentModel.DataAnnotations;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class DeliveryLineEntity : EntityBase<int>
{
    public virtual PartEntity Part {get;set;}
    public int Quantity {get;set;}
}