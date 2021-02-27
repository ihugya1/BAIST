﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class TeeTime
    {
        public DateTime TeeTimeDate { get; set; }
        public DateTime TeeTimeTime { get; set; }
        public int MemberNumber { get; set; }
      public int NumPlayers { get; set; }
      public int NumCarts { get; set; }
      public string EmployeeName { get; set; }
      public bool IsStandingTeeTime { get; set; }
        public bool IsSpecialEvent { get; set; }
    }
}