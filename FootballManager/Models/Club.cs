using System;

namespace FootballManager.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public int FoundedYear { get; set; }
    }
}