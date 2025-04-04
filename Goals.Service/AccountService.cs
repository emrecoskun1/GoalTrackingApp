using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;
using Goals.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Goals.Service;

public class AccountService
{
    private string connectionString = "";
    public AccountService(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public object GetAccount(RequestMessage request)
    {
        var dto = request.Get<AccountDto>();
        dto = JsonConvert.DeserializeObject<AccountDto>(request.Data.ToString());
        
        EAccount eAccount = new EAccount(new Database(connectionString));           
        var response = eAccount.GetAccountByAccountNumber(dto);
        
        return response;
    }

    public object? CreateAccount(RequestMessage request)
    {
        var dto = request.Get<CreateAccountDto>();
        dto = JsonConvert.DeserializeObject<CreateAccountDto>(request.Data.ToString());
        
        EAccount eAccount = new EAccount(new Database(connectionString));           
        var response = eAccount.CreateAccount(dto);
        
        return response;
    }

    public object? DeleteAccount(RequestMessage request)
    {
        var dto = request.Get<AccountDto>();
        dto = JsonConvert.DeserializeObject<AccountDto>(request.Data.ToString());
        
        EAccount eAccount = new EAccount(new Database(connectionString));           
        var response = eAccount.DeleteAccount(dto);
        
        return response;
    }

    public object? UpdateAccount(RequestMessage request)
    {
        var dto = request.Get<AccountDto>();
        dto = JsonConvert.DeserializeObject<AccountDto>(request.Data.ToString());
        
        EAccount eAccount = new EAccount(new Database(connectionString));           
        var response = eAccount.UpdateAccount(dto);
        
        return response;
    }

    public object? GetAllAccounts()
    {
        
        EAccount eAccount = new EAccount(new Database(connectionString));
        var request = new RequestMessage();
        var response = eAccount.GetAllAccounts();
        return response;
        
    }
}