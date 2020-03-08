using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    internal interface IEmployeeRepository
    {
        Task Insert(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetAll(EmployeeDTO employee);
        Task Update(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetActives(EmployeeDTO employee);
        Task Disable(EmployeeDTO employee);
        Task Delete(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetLocationByID(int ID);
    }
}
