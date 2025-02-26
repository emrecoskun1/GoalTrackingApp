namespace Creed.DataAccess;

using System;
using System.Data;
using System.Data.Common;

public abstract class BaseDatabase
{
    protected string ConnectionString;
    
    public abstract DataSet ExecuteDataSet(string spName, DatabaseParameters parameters);
}
