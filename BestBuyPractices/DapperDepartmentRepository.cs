using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection; 
        public DapperDepartmentRepository(IDbConnection connection)
        { 
        _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {


            var depos = _connection.Query<Department>("Select * from departments");
            return depos;
                
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
    }
}
