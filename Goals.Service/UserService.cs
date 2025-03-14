using Creed.Common;
using Creed.DataAccess;
using Goals.Entity;
using Microsoft.Extensions.Configuration;

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
    
}