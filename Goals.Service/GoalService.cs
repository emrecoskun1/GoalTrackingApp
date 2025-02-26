using Creed.DataAccess;
using Goals.Entity;
using Microsoft.Extensions.Configuration;

namespace Goals.Service;

public class GoalService
{
    private string connectionString = "";
    public GoalService(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public object GetGoals()
    {
        EGoal eGoal = new EGoal(new Database(connectionString));
        var response = eGoal.GetGaolsById();
        return response;
    }
}