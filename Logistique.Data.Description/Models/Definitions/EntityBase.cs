using System.ComponentModel.DataAnnotations;

namespace Logistique.Data.Description.Models.Definitions;

public class EntityBase<TKey> : IEntityBase<TKey>
{
    public string CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModificationDate { get; set; }
    [Key]
    public TKey Id { get; set; }
}