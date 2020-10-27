using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    public interface IOfficeAssignmentService:IGenericService<OfficeAssignment>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
