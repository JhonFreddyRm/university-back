using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace University.BL.DTOs
{
    public enum Grade
    {
        A, B, C, D, E
    }

    public class EnrollmentDTO
    {
        [Required(ErrorMessage = "El campo EnrollmentID es requerido")]
        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "El campo CourseID es requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El campo StudentID es requerido")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "El campo Grade es requerido")]
        public Grade Grade { get; set; }


        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }
    }
}
