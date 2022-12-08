namespace Logistique.Business.BusinessModel;

public class Stock 
{
    public int Quantity {get;set;}
    public int PartId {get;set;}
    public Part Part {get;set;}
}