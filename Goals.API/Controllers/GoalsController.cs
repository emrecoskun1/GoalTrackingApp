using Creed.DataAccess;
using Goals.Service;
using Microsoft.AspNetCore.Mvc;

namespace Goals.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GoalsController : ControllerBase
{
    private GoalService _goalService;

    public GoalsController(GoalService gs)
    {
        _goalService = gs;
    }

    public IActionResult Get()
    {
        // DatabaseParameters parameters = new DatabaseParameters();
        // parameters.Add("Id","1");
        // _database.ExecuteDataSet("SPNAME", parameters);
        _goalService.GetGoals();
        return Ok();
    }
}