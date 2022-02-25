using MongoDB.Driver;
using MongoDBApi.Models;

namespace MongoDBApi.Service
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IEmployeeDatabaseSettings settings, IMongoClient client)
        {


            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

        }

        public List<Employee> Get()
        {
            
            return _employees.Find(emp=>true).ToList();
        }

        public Employee Get(string id)
        {
            return _employees.Find<Employee>(emp => emp.Id == id).FirstOrDefault();
        }
    }
}
