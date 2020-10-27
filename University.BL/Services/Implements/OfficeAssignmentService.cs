using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class OfficeAssignmentService:GenericService<OfficeAssignment>, IOfficeAssignmentService
    {
        private readonly IOfficeAssignmentRepository officeAssignmentRepository;
        public OfficeAssignmentService(IOfficeAssignmentRepository officeAssignmentRepository):base(officeAssignmentRepository)
        {
            this.officeAssignmentRepository = officeAssignmentRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await officeAssignmentRepository.DeleteCheckOnEntity(id);
        }
    }
}
