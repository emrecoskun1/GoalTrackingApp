namespace Goals.Common.Dtos;


public class UserDto
{
    //api kullanıcısı 
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public  string? UserEmail { get; set; }
    
    public string? UserRole { get; set; }
    public string? UserPassword { get; set; }
    
    
}