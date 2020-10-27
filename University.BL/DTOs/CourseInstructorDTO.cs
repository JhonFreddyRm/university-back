using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int InstructorID { get; set; }
        
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
