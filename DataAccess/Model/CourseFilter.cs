using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class CourseFilter
    {
        public int? CourseId { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }
    }
}
