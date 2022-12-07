namespace Logistique.Data.Description.Models.Definitions;

public interface IEntityBase<TKey> : ITrackedEntity
{
    TKey Id { get; set; }
}