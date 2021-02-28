using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTPrototype.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTPrototype.Pages.Player
{
    public class RecordsPlayerScoresModel : PageModel
    {
  
        public string Message { get; set; }
        [BindProperty]
        [Required]
        public DateTime GolfGateDate { get; set; }
        [BindProperty]
        [Required]
        public int MemberNumberField { get; set; }
        [BindProperty]
        [Required]
        public string GolfCourseField { get; set; }
        [BindProperty]
        [Required]
        public decimal CourseRatingField { get; set; }
        [BindProperty]
        [Required]
        public decimal SlopeRatingField { get; set; }
        [BindProperty]
        [Required]
        public int Hole1Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole2Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole3Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole4Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole5Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole6Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole7Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole8Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole9Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole10Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole11Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole12Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole13Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole14Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole15Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole16Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole17Field { get; set; }
        [BindProperty]
        [Required]
        public int Hole18Field { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {

            int total = 0;
            // Message = "OnPost";
            if (ModelState.IsValid)
            {
                
                int Confirmation;
                List<GolfGameHole> holes = new List<GolfGameHole>();
                GolfGameHole golfGameHole1 = new GolfGameHole
                {
                    HoleNumber = 1,
                    Score = Hole1Field,

                };
                holes.Add(golfGameHole1);
               
                GolfGameHole golfGameHole2 = new GolfGameHole
                {
                    HoleNumber = 2,
                    Score = Hole2Field,

                };
                holes.Add(golfGameHole2);
                GolfGameHole golfGameHole3 = new GolfGameHole
                {
                    HoleNumber = 3,
                    Score = Hole3Field,

                };
                holes.Add(golfGameHole3);
                GolfGameHole golfGameHole4 = new GolfGameHole
                {
                    HoleNumber = 4,
                    Score = Hole4Field,

                };
                holes.Add(golfGameHole4);
                GolfGameHole golfGameHole5 = new GolfGameHole
                {
                    HoleNumber = 5,
                    Score = Hole5Field,

                };
                holes.Add(golfGameHole5);
                GolfGameHole golfGameHole6 = new GolfGameHole
                {
                    HoleNumber = 6,
                    Score = Hole6Field,

                };
                holes.Add(golfGameHole6);
                GolfGameHole golfGameHole7 = new GolfGameHole
                {
                    HoleNumber = 7,
                    Score = Hole7Field,

                };
                holes.Add(golfGameHole7);
                GolfGameHole golfGameHole8 = new GolfGameHole
                {
                    HoleNumber = 8,
                    Score = Hole8Field,

                };
                holes.Add(golfGameHole8);
                GolfGameHole golfGameHole9 = new GolfGameHole
                {
                    HoleNumber = 9,
                    Score = Hole9Field,

                };
                GolfGameHole golfGameHole10 = new GolfGameHole
                {
                    HoleNumber = 10,
                    Score = Hole10Field,

                };
                holes.Add(golfGameHole10);
                GolfGameHole golfGameHole11 = new GolfGameHole
                {
                    HoleNumber = 11,
                    Score = Hole11Field,

                };
                holes.Add(golfGameHole11);
                GolfGameHole golfGameHole12 = new GolfGameHole
                {
                    HoleNumber = 12,
                    Score = Hole12Field,

                };
                holes.Add(golfGameHole12);
                GolfGameHole golfGameHole13 = new GolfGameHole
                {
                    HoleNumber = 13,
                    Score = Hole13Field,

                };
                holes.Add(golfGameHole13);
                GolfGameHole golfGameHole14 = new GolfGameHole
                {
                    HoleNumber = 14,
                    Score = Hole14Field,

                };
                holes.Add(golfGameHole14);
                GolfGameHole golfGameHole15 = new GolfGameHole
                {
                    HoleNumber = 15,
                    Score = Hole15Field,

                };
                holes.Add(golfGameHole15);
                GolfGameHole golfGameHole16 = new GolfGameHole
                {
                    HoleNumber = 16,
                    Score = Hole16Field,

                };
                holes.Add(golfGameHole16);
                GolfGameHole golfGameHole17 = new GolfGameHole
                {
                    HoleNumber = 17,
                    Score = Hole17Field,

                };
                holes.Add(golfGameHole17);
                GolfGameHole golfGameHole18 = new GolfGameHole
                {
                    HoleNumber = 18,
                    Score = Hole18Field,

                };
                holes.Add(golfGameHole18);
                foreach (var hole in holes)
                {
                    total += hole.Score;
                }
                GolfGame golfGame = new GolfGame
                {
                    MemberNumber = MemberNumberField,
                    GolfCourse = GolfCourseField,
                    GolfGameDate = GolfGateDate,
                    CourseRating = CourseRatingField,
                    SlopeRating = SlopeRatingField,
                    TotalScore = total,
                    holeList = holes

                };
                CBS RequestDirector = new CBS();
                Confirmation = RequestDirector.AddGameScore(golfGame);
                Message = $" {golfGame.GolfCourse}:{Confirmation} added";
            }
            else
            {
                Message = $"Not Valid";
            }
        }
    }
}