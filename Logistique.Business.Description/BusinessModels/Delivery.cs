namespace Logistique.Business.BusinessModel;

public class Delivery
{
    public int Id {get;set;}
    public List<DeliveryLine> DeliveryLines {get;set;}
}