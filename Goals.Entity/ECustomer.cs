using System.Data;
using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;

namespace Goals.Entity;

public class ECustomer
{
    private Database _database;
    public ECustomer(Database db)
    {
        _database = db;
    }
    
    
    public ResponseMessage GetCustomerByCustomerNumber(CustomerDto dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;


        var parameters = new DatabaseParameters();
        parameters.Add("@CUSTOMERNUMBER", dto.CustomerNumber);
        
        var result = _database.ExecuteDataSet("sp_GetCustomerByCustomerNumber", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<CustomerDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new CustomerDto
                { 
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    Status = Convert.ToInt32(row["Status"]),
                    CustomerType = Convert.ToInt32(row["CustomerType"]),
                    TCNumber = row["TCNumber"].ToString(),
                    CustomerName = row["CustomerName"].ToString(),
                    CustomerSurname = row["CustomerSurname"].ToString(),
                    CustomerMotherName = row["CustomerMotherName"].ToString(),
                    CustomerFatherName = row["CustomerFatherName"].ToString(),
                    CustomerBirthDate = row["CustomerBirthDate"] != DBNull.Value ? Convert.ToDateTime(row["CustomerBirthDate"]) : (DateTime?)null,
                    CustomerGender = Convert.ToInt32(row["CustomerGender"]),
                    MaritalStatus = row["MaritalStatus"].ToString(),
                    RecordDate = row["RecordDate"] != DBNull.Value ? Convert.ToDateTime(row["RecordDate"]) : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }

            response.Data = customersList;
        }

        return response;

    }

    public object? CreateCustomer(CreateCustomerDto dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;
        
        var parameters = new DatabaseParameters();
        parameters.Add("@CustomerNumber", dto.CustomerNumber);
        parameters.Add("@Status", dto.Status);
        parameters.Add("@CustomerType", dto.CustomerType);
        parameters.Add("@TCNumber", dto.TCNumber);
        parameters.Add("@CustomerName", dto.CustomerName);
        parameters.Add("@CustomerSurname", dto.CustomerSurname);
        parameters.Add("@CustomerMotherName", dto.CustomerMotherName);
        parameters.Add("@CustomerFatherName", dto.CustomerFatherName);
        parameters.Add("@CustomerBirthDate", dto.CustomerBirthDate);
        parameters.Add("@CustomerGender", dto.CustomerGender);
        parameters.Add("@MaritalStatus", dto.MaritalStatus);
        parameters.Add("@RecordDate", dto.RecordDate);
        parameters.Add("@RecordUser", dto.RecordUser);
        parameters.Add("@RecordScreenCode", dto.RecordScreenCode);
        
        var result = _database.ExecuteDataSet("sp_CreateCustomer", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<CreateCustomerDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new CreateCustomerDto()
                { 
                    CustomerNumber = row["CustomerNumber"].ToString(),
                });
            }
//if   effected row 1 ise başarılı
            response.Data = customersList;
        }
        
        return response;
        
    }

    public object DeleteCustomer(DeleteCustomerDto dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;
        
        var parameters = new DatabaseParameters();
        parameters.Add("@CustomerNumber", dto.CustomerNumber);
        
        var result = _database.ExecuteDataSet("sp_DeleteCustomerByCustomerNumber", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<DeleteCustomerDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new DeleteCustomerDto()
                { 
                    CustomerNumber = row["CustomerNumber"].ToString(),
                });
            }
            
            response.Data = customersList;
            
        }
        return response;
    }

    public object? UptadeCustomer(UpdateCustomerDto? dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;
        
        var parameters = new DatabaseParameters();
        parameters.Add("@CustomerNumber", dto.CustomerNumber);
        parameters.Add("@Status", dto.Status);
        parameters.Add("@CustomerType", dto.CustomerType);
        parameters.Add("@CustomerName", dto.CustomerName);
        parameters.Add("@CustomerSurname", dto.CustomerSurname);
        parameters.Add("@CustomerMotherName", dto.CustomerMotherName);
        parameters.Add("@CustomerFatherName", dto.CustomerFatherName);
        parameters.Add("@CustomerGender", dto.CustomerGender);
        parameters.Add("@MaritalStatus", dto.MaritalStatus);
        parameters.Add("@RecordDate", dto.RecordDate);
        parameters.Add("@RecordUser", dto.RecordUser);
        parameters.Add("@RecordScreenCode", dto.RecordScreenCode);
        
        var result = _database.ExecuteDataSet("sp_UpdateCustomer", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<UpdateCustomerDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new UpdateCustomerDto()
                { 
                    Status = Convert.ToInt32(row["Status"]),
                    CustomerType = Convert.ToInt32(row["CustomerType"]),
                    CustomerName = row["CustomerName"].ToString(),
                    CustomerSurname = row["CustomerSurname"].ToString(),
                    CustomerMotherName = row["CustomerMotherName"].ToString(),
                    CustomerFatherName = row["CustomerFatherName"].ToString(),
                    CustomerGender = Convert.ToInt32(row["CustomerGender"]),
                    MaritalStatus = row["MaritalStatus"].ToString(),
                    RecordDate = row["RecordDate"] != DBNull.Value ? Convert.ToDateTime(row["RecordDate"]) : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }
            
            response.Data = customersList;
            
        }
        return response;
    }
}