using System.Data;
using Creed.DataAccess;

namespace Goals.Entity;

public class EGoal
{
    private Database _database;
    public EGoal(Database db)
    {
        _database = db;
    }
    public object GetGaolsById()
    {
        ///fgdfgdfgdgd
        var parameters = new DatabaseParameters();
        parameters.Add("Id", "1");
        parameters.Add("Id", "2");
        parameters.Add("Id", "3");
        if (parameters== null)
            throw new NotSupportedException("Parametre boş olamaz.");

        return typeof(DataSet);
    }
    
    void PrintName(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name), "İsim null olamaz!");
        Console.WriteLine(name);
    }
    
    void SetAge(int age)
    {
        if (age < 0)
            throw new ArgumentException(nameof(age), "Yaş 0'dan büyük olmalıdır.");
        Console.WriteLine(age);
    }
    

}

class MyClass
{
    private bool isInitialized = false;
    
    public void DoSomething()
    {
        if (!isInitialized)
            throw new InvalidOperationException("Nesne başlatılmamış.");
        Console.WriteLine("ACILLL!");
    }
}



public class Class2
{
    public string str = null;
    
}

public class Class1: Class2
{
    Class2 e  = new Class2();
    public void DoSomething()
    {
        if (e.str == null)
            throw new NullReferenceException("Null olamaz.");
        Console.WriteLine("ACILLL!");
    }

}
