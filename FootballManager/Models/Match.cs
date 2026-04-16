using System;

namespace FootballManager.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int RoundNo { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public DateTime MatchDate { get; set; }
        public string HomeClubName { get; set; }
        public string AwayClubName { get; set; }
    }
}