using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class GolfGame
    {
        public int GolfRoundID { get; set; }
        public int MemberNumber { get; set; }
        public DateTime GolfGameDate { get; set; }
        public string GolfCourse { get; set; }
        public decimal CourseRating { get; set; }
        public decimal SlopeRating { get; set; }
        public int TotalScore { get; set; }
        public List<GolfGameHole> holeList = new List<GolfGameHole>();
    }
}
