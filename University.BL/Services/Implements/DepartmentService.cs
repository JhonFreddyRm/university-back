using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class DepartmentService:GenericService<Department>, IDepartmentService
    {

        private readonly IDepartmentsRepository departmentsRepository;

        public DepartmentService(IDepartmentsRepository departmentsRepository):base(departmentsRepository)
        {
            this.departmentsRepository = departmentsRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await departmentsRepository.DeleteCheckOnEntity(id);
        }
    }
}
