﻿using BAIS3150_OOPAssignment01_IanHugya_OA02.BLL;
using BAIS3150_OOPAssignment01_IanHugya_OA02.DAL;

using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150_OOPAssignment01_IanHugya_OA02.BLL
{
    class CodeHandler
    {
        //Conroller = Call the Manager -> Return what was returned
        public bool AddCourse(Course aNewCourse)
        {
            Console.WriteLine("HIT");
            bool confirmation;
            Courses courseManager = new Courses();
            confirmation = courseManager.AddCourse(aNewCourse);
            return confirmation;
        }
    }
}
