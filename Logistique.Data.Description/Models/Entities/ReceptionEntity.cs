using System.ComponentModel.DataAnnotations;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class DeliveryEntity : EntityBase<int>
{
    public virtual List<DeliveryLineEntity> DeliveryLines {get;set;}
}