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
    public class InstructorRepository:GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly UniversityContext universityContext;

        public InstructorRepository(UniversityContext universityContext):base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.CourseInstructors.AnyAsync(x => x.InstructorID == id);
            return flag;
        }
    }
}
