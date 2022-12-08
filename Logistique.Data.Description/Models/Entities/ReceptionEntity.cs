using System.ComponentModel.DataAnnotations;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class ReceptionEntity : EntityBase<int>
{
    public virtual List<LigneReceptionEntity> LigneReceptions {get;set;}
}