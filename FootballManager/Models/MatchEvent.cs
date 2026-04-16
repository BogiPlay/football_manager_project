using System;

namespace FootballManager.Models
{
    public class MatchEvent
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int ClubId { get; set; }
        public string EventType { get; set; }
        public int Minute { get; set; }
    }
}