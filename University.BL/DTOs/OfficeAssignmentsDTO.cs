using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentsDTO
    {
        [Required]
        public int InstructorID { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
