using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Required]
        public int InstructorID { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
       
        public InstructorDTO Instructor { get; set; }
    }
}
