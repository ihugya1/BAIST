﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIST3150RazorPagesNETCore31.Domain
{
    public class DatabaseUser
    {
        public string CurrentUser { get; set; }
        public string SystemUser { get; set; }
        public string SessionUser { get; set; }
    }
}
