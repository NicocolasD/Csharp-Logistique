namespace Logistique.Data.Description.Models.Definitions;

public interface ITrackedEntity
{
    string CreatedBy { get; set; }
    DateTime CreationDate { get; set; }
    string LastModifiedBy { get; set; }
    DateTime LastModificationDate { get; set; }
}