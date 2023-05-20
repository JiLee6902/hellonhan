using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class EnrollmentFilter
    {
        public int? EnrollmentId{ get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? Grade { get; set; }
    }
}
