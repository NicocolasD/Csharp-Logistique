using System.ComponentModel.DataAnnotations;

namespace Logistique.Data.Description.Models.Definitions;

public class EntityBase<TKey> : IEntityBase<TKey>
{
    public string CreatedBy { get; set; } = "ANONYMOUS";
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string LastModifiedBy { get; set; } = "ANONYMOUS";
    public DateTime LastModificationDate { get; set; } = DateTime.Now;
    [Key]
    public TKey Id { get; set; }
}