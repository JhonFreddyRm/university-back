using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class StudentDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        
        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); }
        }
    }
}
