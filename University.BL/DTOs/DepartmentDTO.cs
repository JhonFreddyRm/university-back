using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int InstructorID { get; set; }        
        public InstructorDTO Instructor { get; set; }
    }
}
