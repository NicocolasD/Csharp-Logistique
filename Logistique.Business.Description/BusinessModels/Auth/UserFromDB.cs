namespace Logistique.Business.Description.BusinessModel;

public class UserFromDB
{
    public string Username {get;set;}
    public byte[] PasswordHash {get;set;}
    public byte[] PasswordSalt {get;set;}
    public string Email {get;set;}
    public string Firstname {get;set;}
    public string Lastname {get;set;}
}