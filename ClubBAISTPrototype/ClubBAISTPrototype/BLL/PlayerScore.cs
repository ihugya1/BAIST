using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class PlayerScore
    {
        public int MemberNumber { get; set; }
        public string FullName { get; set; }
        public decimal HandicapIndex { get; set; }
        public decimal Last20Average { get; set; }
        public decimal Best8Average {get;set;}
        public List<int> Last20RoundScore = new List<int>();
    }
}
