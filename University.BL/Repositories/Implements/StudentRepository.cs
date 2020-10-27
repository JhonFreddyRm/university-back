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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly UniversityContext universityContext;

        public StudentRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.Enrollments.AnyAsync(x => x.StudentID == id);
            return flag;
        }

    }
}
