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
            error = membershipManager.InsertMembershipApplication(newApplication, "","");
            return error;
        }
        public MembershipApplication GetMembershipApplication(int applicationID)
        {
            MembershipApplication membershipApplication;
            MembershipApplications membershipManager = new MembershipApplications();
            membershipApplication = membershipManager.GetMembershipApplication(applicationID, "", "");
            return membershipApplication;
        }
        public List<MembershipApplication> SearchApplicationsByParam(string searchParam)
        {
            List<MembershipApplication> applicationList = new List<MembershipApplication>();
            MembershipApplications membershipManager = new MembershipApplications();
            applicationList = membershipManager.GetMembershipApplications(searchParam, "", "");
            return applicationList;
        }
        public bool ApproveMembershipApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.ApproveMembershipApplication(applicationNum, "", "");
            return Confirmation;
        }
        public bool RejectMembershipApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.RejectMembershipApplication(applicationNum, "", "");
            return Confirmation;
        }
        public bool WaitListApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.WaitListMembershipApplicaiton(applicationNum, "", "");
            return Confirmation;
        }
        public bool HoldApplication(int applicationNum)
        {
            bool Confirmation;
            MembershipApplications membershipManager = new MembershipApplications();
            Confirmation = membershipManager.HoldMembershipApplication(applicationNum, "", "");
            return Confirmation;
        }
        public int AddGameScore(GolfGame newScoreCard)
        {
            int code;
            PlayerScores scoreManager = new PlayerScores();
            code = scoreManager.InsertGolfGame(newScoreCard, "", "");
            return code;
        }
        public List<TeeTime> GetDailyTeeTimeSheet(DateTime searchParam)
        {
            List<TeeTime> itemList = new List<TeeTime>();
            TeeTimes teeTimeManager = new TeeTimes();
            itemList = teeTimeManager.GetDailyTeeSheetByDay(searchParam, "", "");
            return itemList;
        }
        public void CreateTeeSheet(DateTime searchParam)
        {
            
            TeeTimes teeTimeManager = new TeeTimes();
            teeTimeManager.CreateDailySheet(searchParam, "", "");
            
        }
        public TeeTime GetTeeTime(DateTime teeDate, DateTime teeTime)
        {
            TeeTime getTeeTime;
            TeeTimes teeTimeManager = new TeeTimes();
            getTeeTime = teeTimeManager.GetTeeTime(teeDate, teeTime, "", "");
            return getTeeTime;
        }
        public bool BookNewTeeTime(TeeTime newTeeTime)
        {
            bool Confirmation;
            TeeTimes teeTimeManager = new TeeTimes();
            Confirmation = teeTimeManager.InsertTeeTime(newTeeTime, "", "");
            return Confirmation;
        }
        public bool RemoveTeeTime(TeeTime newTeeTime)
        {
            bool Confirmation;
            TeeTimes teeTimeManager = new TeeTimes();
            Confirmation = teeTimeManager.DeleteTeeTime(newTeeTime, "", "");
            return Confirmation;
        }
        public bool UpdateTeeTime(TeeTime newTeeTime)
        {
            bool Confirmation;
            TeeTimes teeTimeManager = new TeeTimes();
            Confirmation = teeTimeManager.ModifyTeeTime(newTeeTime, "", "");
            return Confirmation;
        }
        public List<int> GetLast20Scores(int memberNumber)
        {
            List<int> itemList = new List<int>();
            PlayerScores teeTimeManager = new PlayerScores();
            itemList = teeTimeManager.GetLast20Scores(memberNumber, "", "");
            return itemList;
        }
        public decimal GetHandicapIndex(int memberNumber)
        {
            decimal handicap;
            PlayerScores teeTimeManager = new PlayerScores();
            handicap = teeTimeManager.GetHandicap(memberNumber, "", "");
            return handicap;
        }
        public string GetMemberName(int memberNumber)
        {
            string name;
            PlayerScores teeTimeManager = new PlayerScores();
            name = teeTimeManager.GetMemberName(memberNumber, "", "");
            return name;
        }
        public bool InsertStandingTeeTimeRequest(StandingTeeTime newStandingTeeTimeRequest)
        {
            bool Confirmation;
            StandingTeeTimes standingTeeTimeManager = new StandingTeeTimes();
            Confirmation = standingTeeTimeManager.InsertStandingTeeTimeRequest(newStandingTeeTimeRequest, "", "");
            return Confirmation;
        }
        public bool ModifyStandingTeeTime(StandingTeeTime newStandingTeeTimeRequest)
        {
            bool Confirmation;
            StandingTeeTimes standingTeeTimeManager = new StandingTeeTimes();
            Confirmation = standingTeeTimeManager.ModifyStandingTeeTimeRequest(newStandingTeeTimeRequest, "", "");
            return Confirmation;
        }
        public List<StandingTeeTime> GetStandingTeeTimeList()
        {
            List<StandingTeeTime> standingTeeTimes = new List<StandingTeeTime>();
            StandingTeeTimes standingManager = new StandingTeeTimes();
            standingTeeTimes = standingManager.GetStandingTeeTimeRequests("", "");
            return standingTeeTimes;
        }
    }
}
