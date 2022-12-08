using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class DeliveryLineEntity : EntityBase<int>
{
    public int PartId {get;set;}
    public virtual PartEntity Part {get;set;}
    public int Quantity {get;set;}
}