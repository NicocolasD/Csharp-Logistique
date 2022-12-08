namespace Logistique.Business.BusinessModel;

public class Stock 
{
    public int Quantity {get;set;}
    public int ArticleId {get;set;}
    public Article Article {get;set;}
}