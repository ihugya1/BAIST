using ClubBAISTPrototype.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBAISTPrototype.BLL
{
    public class CBS
    {
        public bool AddMembershipApplication(MembershipApplication newApplication)
        {
            bool error;
            MembershipApplications membershipManager = new MembershipApplications();
            error = membershipManager.InsertMembershipApplication(newApplication, "ihugya1","SimpCord101");
            return error;
        }
        public MembershipApplication GetMembershipApplication(int applicationID)
        {
            MembershipApplication membershipApplication;
            MembershipApplications membershipManager = new MembershipApplications();
            membershipApplication = membershipManager.GetMembershipApplication(applicationID, "ihugya1", "SimpCord101");
            return membershipApplication;
        }
        public List<MembershipApplication> SearchApplicationsByParam(string searchParam)
        {
            List<MembershipApplication> applicationList = new List<MembershipApplication>();
            MembershipApplications membershipManager = new MembershipApplications();
            applicationList = membershipManager.GetMembershipApplications(searchParam, "ihugya1", "SimpCord101");
            return applicationList;
        }
        public bool ApproveMembershipApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.ApproveMembershipApplication(applicationNum, "ihugya1", "SimpCord101");
            return Confirmation;
        }
        public bool RejectMembershipApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.RejectMembershipApplication(applicationNum, "ihugya1", "SimpCord101");
            return Confirmation;
        }
        public int AddGameScore(GolfGame newScoreCard)
        {
            int code;
            PlayerScores scoreManager = new PlayerScores();
            code = scoreManager.InsertGolfGame(newScoreCard, "ihugya1", "SimpCord101");
            return code;
        }
        public List<TeeTime> GetDailyTeeTimeSheet(DateTime searchParam)
        {
            List<TeeTime> itemList = new List<TeeTime>();
            TeeTimes teeTimeManager = new TeeTimes();
            itemList = teeTimeManager.GetDailyTeeSheetByDay(searchParam, "ihugya1", "SimpCord101");
            return itemList;
        }
        public void CreateTeeSheet(DateTime searchParam)
        {
            
            TeeTimes teeTimeManager = new TeeTimes();
            teeTimeManager.CreateDailySheet(searchParam, "ihugya1", "SimpCord101");
            
        }
    }
}
