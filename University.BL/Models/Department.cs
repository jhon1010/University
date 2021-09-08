using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace University.BL.Models
{
    [Table("Department", Schema = "dbo")]
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Budget { get; set; }
        public string StartDate { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
}

}