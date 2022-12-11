using System.ComponentModel.DataAnnotations;
using Logistique.Data.Description.Models.Definitions;

namespace Logistique.Data.Description.Models.Entities;

public class UserEntity : EntityBase<int>
{
    [Required]
    public string Username {get;set;}
    [Required]
    public byte[] PasswordHash {get;set;}
    public byte[] PasswordSalt {get;set;}
    [Required, EmailAddress]
    public string Email {get;set;}
    [Required]
    public string Firstname {get;set;}
    [Required]
    public string Lastname {get;set;}
}