using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    public interface IDepartmentService:IGenericService<Department>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
