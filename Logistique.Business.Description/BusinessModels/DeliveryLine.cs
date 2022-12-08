namespace Logistique.Business.BusinessModel;

public class DeliveryLine
{
    public int PartId {get;set;}
    public Part? Part {get;set;}
    public int Quantity {get;set;}
}