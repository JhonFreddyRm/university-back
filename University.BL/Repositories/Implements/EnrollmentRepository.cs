using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class EnrollmentRepository:GenericRepository<Enrollment>
    {
        public EnrollmentRepository(UniversityContext universityContext):base(universityContext)
        {

        }
    }
}
