using System.Data;

namespace Creed.DataAccess;

using System.Collections.Generic;

public class DatabaseParameters: List<DatabaseParameter>
{
    public DatabaseParameter this[string name]{
         get {
             return this.Find(p => p.Name == name);
         }  
         set {
             var index = this.FindIndex(p => p.Name == name);
             if (index != -1)
             {
                 this[index] = value;
             }
             else
             {
                 Add(value);
             }
         }
         
    }
    

    public void Add(string name, object value, DbType type = DbType.String)
    {
        Add(new DatabaseParameter(name, value, type));
    }
    
    public bool HasParameter(string name)
    {
        return this.Exists(p => p.Name == name);
    }

}
