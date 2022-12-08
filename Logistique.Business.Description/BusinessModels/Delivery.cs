namespace Logistique.Business.Description.BusinessModel;

public class Delivery
{
    public int Id {get;set;}
    public DeliveryState State {get;set;}
    public List<DeliveryLine> DeliveryLines {get;set;}
}