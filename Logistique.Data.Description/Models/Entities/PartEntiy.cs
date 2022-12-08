using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class PartEntity : EntityBase<int>
{
    [Required]
    public string Ean {get;set;}
    [Required]
    public string Description{get;set;}
    [Required]
    public string PartNo {get;set;}
}