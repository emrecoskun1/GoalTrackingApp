using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;
using Goals.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Goals.Service;

public class UserService
{
    private string connectionString = "";
    public UserService(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public object GetUsers()
    {
        EUser eUser = new EUser(new Database(connectionString));
        var request = new RequestMessage();
        var response = eUser.GetUsers(request);
        return response;      
    }


    public object GetUserWithResponse(RequestMessage request)
    {
        var dto = request.Get<UserDto>();
        dto = JsonConvert.DeserializeObject<UserDto>(request.Data.ToString());
        
        // Veritabanı işlemi için DTO'yu kullanıyoruz.
        EUser eUser = new EUser(new Database(connectionString));
        var response = eUser.GetUsersByAuth(dto);
    
        return response;
    }
    
}