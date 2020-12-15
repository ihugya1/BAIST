using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS_UI_Test.BLL
{
    public class ProgramName
    {
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public List<Student> EnrolledStudents { get; set; }
    }
}
