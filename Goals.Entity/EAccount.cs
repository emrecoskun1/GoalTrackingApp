using System.Data;
using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace Goals.Entity;

public class EAccount
{

    private Database _database;

    public EAccount(Database db)
    {
        _database = db;
    }

    public ResponseMessage GetAccountByAccountNumber(AccountDto dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;


        var parameters = new DatabaseParameters();
        parameters.Add("ACCOUNTNUMBER", dto.AccountNumber);

        var result = _database.ExecuteDataSet("sp_GetAccountByAccountNumber", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<AccountDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new AccountDto()
                {
                    AccountNumber = row["AccountNumber"].ToString(),
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    AccountType = Convert.ToInt32(row["AccountType"]),
                    AccountCurrencyType = row["AccountCurrencyType"].ToString(),
                    AccountIsBlocked = Convert.ToBoolean(row["AccountIsBlocked"]),
                    AccountBalance = Convert.ToDouble(row["AccountBalance"]),
                    RecordDate = row["RecordDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["RecordDate"])
                        : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }

            response.Data = customersList;
        }

        return response;

    }

    public object? CreateAccount(CreateAccountDto? dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;

        var parameters = new DatabaseParameters();
        parameters.Add("@CustomerNumber", dto.CustomerNumber);
        parameters.Add("@AccountNumber", dto.AccountNumber);
        parameters.Add("@AccountType", dto.AccountType);
        parameters.Add("@AccountCurrencyType", dto.AccountCurrencyType);
        parameters.Add("@AccountIsBlocked", dto.AccountIsBlocked);
        parameters.Add("@AccountBalance", dto.AccountBalance);
        parameters.Add("@RecordDate", dto.RecordDate);
        parameters.Add("@RecordUser", dto.RecordUser);
        parameters.Add("@RecordScreenCode", dto.RecordScreenCode);

        var result = _database.ExecuteDataSet("sp_CreateAccount", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<CreateAccountDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new CreateAccountDto()
                {
                    AccountNumber = row["AccountNumber"].ToString(),
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    AccountType = Convert.ToInt32(row["AccountType"]),
                    AccountCurrencyType = row["AccountCurrencyType"].ToString(),
                    AccountIsBlocked = Convert.ToBoolean(row["AccountIsBlocked"]),
                    AccountBalance = Convert.ToDouble(row["AccountBalance"]),
                    RecordDate = row["RecordDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["RecordDate"])
                        : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }

//if   effected row 1 ise başarılı
            response.Data = customersList;
        }

        return response;
    }

    public object? DeleteAccount(AccountDto? dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;

        var parameters = new DatabaseParameters();
        parameters.Add("@AccountNumber", dto.AccountNumber);

        var result = _database.ExecuteDataSet("sp_DeleteAccountByAccountNumber", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<DeleteAccountDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new DeleteAccountDto()
                {
                    AccountNumber = row["AccountNumber"].ToString(),
                });
            }

            response.Data = customersList;

        }

        return response;
    }

    public object? UpdateAccount(AccountDto? dto)
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;

        var parameters = new DatabaseParameters();
        parameters.Add("@CustomerNumber", dto.CustomerNumber);
        parameters.Add("@AccountNumber", dto.AccountNumber);
        parameters.Add("@AccountType", dto.AccountType);
        parameters.Add("@AccountCurrencyType", dto.AccountCurrencyType);
        parameters.Add("@AccountIsBlocked", dto.AccountIsBlocked);
        parameters.Add("@AccountBalance", dto.AccountBalance);
        parameters.Add("@RecordDate", dto.RecordDate);
        parameters.Add("@RecordUser", dto.RecordUser);
        parameters.Add("@RecordScreenCode", dto.RecordScreenCode);

        var result = _database.ExecuteDataSet("sp_UpdateAccount", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<UpdateAccountDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new UpdateAccountDto()
                {
                    AccountNumber = row["AccountNumber"].ToString(),
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    AccountType = Convert.ToInt32(row["AccountType"]),
                    AccountCurrencyType = row["AccountCurrencyType"].ToString(),
                    AccountIsBlocked = Convert.ToBoolean(row["AccountIsBlocked"]),
                    AccountBalance = Convert.ToDouble(row["AccountBalance"]),
                    RecordDate = row["RecordDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["RecordDate"])
                        : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }

            response.Data = customersList;

        }

        return response;
    }

    public object? GetAllAccounts()
    {
        ResponseMessage response = new ResponseMessage();
        response.Success = true;

        var parameters = new DatabaseParameters();

        var result = _database.ExecuteDataSet("sp_GetAllAccounts", parameters);

        if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
        {
            var customersList = new List<UpdateAccountDto>();

            foreach (DataRow row in result.Tables[0].Rows)
            {
                customersList.Add(new UpdateAccountDto()
                {
                    AccountNumber = row["AccountNumber"].ToString(),
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    AccountType = Convert.ToInt32(row["AccountType"]),
                    AccountCurrencyType = row["AccountCurrencyType"].ToString(),
                    AccountIsBlocked = Convert.ToBoolean(row["AccountIsBlocked"]),
                    AccountBalance = Convert.ToDouble(row["AccountBalance"]),
                    RecordDate = row["RecordDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["RecordDate"])
                        : (DateTime?)null,
                    RecordUser = row["RecordUser"].ToString(),
                    RecordScreenCode = row["RecordScreenCode"].ToString()
                });
            }

            response.Data = customersList;

        }

        return response;
    }
}