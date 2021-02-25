using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class MembershipApplication
    {
		public int MembershipApplicationID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public char Status { get; set; }
		public string Occupation { get; set; }
		public string CompanyName { get; set; }
		public string HomeAddress { get; set; }
		public string CompanyAddress { get; set; }
		public string HomePostalCode { get; set; }
		public string CompanyPostalCode { get; set; }
		public string HomePhone { get; set; }
		public string CompanyPhone { get; set; }
		public string HomeAlternatePhone { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime DateCompleted { get; set; }
		public string ShareholderName1 { get; set; }
		public string ShareholderName2 { get; set; }
	}
}
