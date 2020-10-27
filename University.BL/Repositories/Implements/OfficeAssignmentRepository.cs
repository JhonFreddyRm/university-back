using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Data;
using System.Data.Entity;

namespace University.BL.Repositories.Implements
{
    public class OfficeAssignmentRepository:GenericRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        private readonly UniversityContext universityContext;
        public OfficeAssignmentRepository(UniversityContext universityContext):base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.Instructors.AnyAsync(x => x.ID == id);
            return flag;
        }
    }
}
