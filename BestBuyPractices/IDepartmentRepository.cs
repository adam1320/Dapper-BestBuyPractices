using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices
{
    public interface IDepartmentRepository
    { 
        //Create a method called getalldepartments that returns a collection
        //that conforms to ienumerable<T>
        IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartmentName);

    }
}
