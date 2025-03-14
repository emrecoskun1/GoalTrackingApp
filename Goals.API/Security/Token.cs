namespace Goals.API.Security;

public class Token
{
    //JWtAyarları
    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    
}