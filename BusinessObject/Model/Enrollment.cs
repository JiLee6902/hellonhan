using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObject.Model
{
    public partial class Enrollment
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }
        [Column("StudentId")]
        public int StudentId { get; set; }
        [Column("CourseId")]
        public int CourseId { get; set; }
        public int Grade { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
