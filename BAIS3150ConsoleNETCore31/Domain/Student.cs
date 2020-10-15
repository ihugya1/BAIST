using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace BAIS3150ConsoleNETCore31.Domain
{
    class Student
    {
        private string _studentID; //Camel Case Preceeded with underscore
        private string _firstName;
        public string StudentID //Pascal Case
        { 
            get 
            {
                return _studentID;
            }
            set 
            {
                _studentID = value;
            }
        }
        public string FirstName //Expression-Bodied Property Accessors
        {
            get => _firstName; //implementation of property acess can be made up of only a single statement 
            set => _firstName = value;
        }
        public string LastName { get; set; }// Auto-Implemented Property, no loginc in get/set
        public string Email { get; set; } 
        public Student()
        {
            // constructor logic
        }
    }
}
