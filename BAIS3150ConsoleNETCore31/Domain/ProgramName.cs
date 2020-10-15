using System;
using System.Collections.Generic;
using System.Text;
namespace BAIS3150ConsoleNETCore31.Domain
{
    class ProgramName
    {
        public string ProgramCode { get; set;}
        public string Description{ get;set;}
        public Student[] EnrolledStudents {get;set;}
    }
}