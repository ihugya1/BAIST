using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class StandingTeeTime
    {
        public int StandingTeeTimeID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime TeeTimeTime { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? ApprovedTeeTime { get; set; }
        public int RequestedDayOfWeek { get; set; }
        public int ShareHolderNumber { get; set; }
        public int MemberNumber2 { get; set; }
        public int MemberNumber3 { get; set; }
        public int MemberNumber4 { get; set; }
        public string ShareHolderName { get; set; }
        public string Member2Name { get; set; }
        public string Member3Name { get; set; }
        public string Member4Name { get; set; }
        public int? NumCarts { get; set; }
        public int? PriorityNumber { get; set; }
        public string EmployeeName { get; set; }
        public int? EmployeeNumber { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
    }
}
