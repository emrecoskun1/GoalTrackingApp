using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;

namespace Goals.Entity;

public class EUser
{
    private Database _database;
    public EUser(Database database)
    {
        _database = database;
    }
    public object GetUsers(RequestMessage request)
    {
        ResponseMessage response = new ResponseMessage();
        
        var dto = request.Data as UserDto;
        
        ///fgdfgdfgdgd
        var parameters = new DatabaseParameters();
        //parameters.Add("UserId", dto.UserId); //dto.UserId
        parameters.Add("UserName", dto.UserName); // dto.Name
        parameters.Add("UserEmail", dto.UserEmail); // dto.Description
        parameters.Add("UserPassword", dto.UserPassword); // dto.Description
        
        var result = _database.ExecuteDataSet("sp_GetUser", parameters);

        if (result.Tables[0].Rows.Count > 0)
        {
            response.Data = new List<GoalDto>();
            // foreach (var row in result.Tables[0].Rows)
            // {
            //     (response.Data as List<GoalDto>).Add(new GoalDto
            //         {
            //             Id = row["Id"].ToInt(),
            //             Name = row["Name"].ToString(),
            //             Status = row["Status"].ToString()
            //         });
            // }
        }
        
        return response;
    }

    public object GetUsersByAuth(UserDto dto)
    {
        return dto;
    }
}