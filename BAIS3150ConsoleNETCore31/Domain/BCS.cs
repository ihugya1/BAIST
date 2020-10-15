using BAIS3150ConsoleNETCore31.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Text;
namespace BAIS3150ConsoleNETCore31.Domain
{
    class BCS
    {
        public bool CreateProgram(string programCode,string description)
        { bool Confirmation; Programs programManager = new Programs(); Confirmation = programManager.AddProgram(programCode,description); return Confirmation; }
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        { bool Confirmation; Students studentManager = new Students(); Confirmation = studentManager.AddStudent(acceptedStudent, programCode); return Confirmation; }
        public Student FindStudent(string studentId)
        { Students studentManager = new Students(); Student student = studentManager.GetStudent(studentId); return student; }
        public bool ModifyStudent(Student enrolledStudent)
        { bool Confirmation; Students studentManager = new Students(); Confirmation = studentManager.UpdateStudent(enrolledStudent); return Confirmation; }
        public bool RemoveStudent(string studentID)
        { bool Confirmation; Students studentManager = new Students(); Confirmation = studentManager.DeleteStudent(studentID); return Confirmation; }
         public ProgramName FindProgram(string programCode)
        { ProgramName program; Programs programManager = new Programs(); program = programManager.GetProgram(programCode); return program; }
    }
}