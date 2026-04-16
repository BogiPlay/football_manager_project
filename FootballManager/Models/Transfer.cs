using System;

namespace FootballManager.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int? FromClubId { get; set; } // Може да е null (свободен агент)
        public int ToClubId { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
    }
}