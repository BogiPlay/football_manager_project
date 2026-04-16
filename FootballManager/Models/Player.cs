using System;

namespace FootballManager.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int KitNumber { get; set; }
        public int? CurrentClubId { get; set; }
    }
}