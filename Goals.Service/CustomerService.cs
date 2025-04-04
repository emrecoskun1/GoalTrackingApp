using Creed.Common;
using Creed.DataAccess;
using Goals.Common.Dtos;
using Goals.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Goals.Service;

public class CustomerService
{
    private string connectionString = "";
    public CustomerService(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public object GetCustomer(RequestMessage request)
    {
        var dto = request.Get<CustomerDto>();
        dto = JsonConvert.DeserializeObject<CustomerDto>(request.Data.ToString());
        
        ECustomer eCustomer = new ECustomer(new Database(connectionString));           
        var response = eCustomer.GetCustomerByCustomerNumber(dto);
        
        return response;
    }

    public object? CreateCustomer(RequestMessage request)
    {
        var dto = request.Get<CreateCustomerDto>();
        dto = JsonConvert.DeserializeObject<CreateCustomerDto>(request.Data.ToString());
        
        ECustomer eCustomer = new ECustomer(new Database(connectionString));
        var response = eCustomer.CreateCustomer(dto);
        
        
        return response;
    }

    public object? DeleteCustomer(RequestMessage request)
    {
        var dto = request.Get<DeleteCustomerDto>();
        dto = JsonConvert.DeserializeObject<DeleteCustomerDto>(request.Data.ToString());
        
        ECustomer eCustomer = new ECustomer(new Database(connectionString));
        var response = eCustomer.DeleteCustomer(dto);

        return response;
    }

    public object? UpdateCustomer(RequestMessage request)
    {
        var dto = request.Get<UpdateCustomerDto>();
        dto = JsonConvert.DeserializeObject<UpdateCustomerDto>(request.Data.ToString());
        
        ECustomer eCustomer = new ECustomer(new Database(connectionString));
        var response = eCustomer.UptadeCustomer(dto);

        return response;
    }
}