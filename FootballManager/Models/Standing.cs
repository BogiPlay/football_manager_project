using System;

namespace FootballManager.Models
{
    public class Standing
    {
        public int Position { get; set; } // Позиция в класирането (1, 2, 3...)
        public int ClubId { get; set; }
        public string ClubName { get; set; } // Име на отбора
        public int MatchesPlayed { get; set; } // Изиграни мачове
        public int Wins { get; set; } // Победи
        public int Draws { get; set; } // Равни
        public int Losses { get; set; } // Загуби

        public int GoalsFor { get; set; } // Отбелязани голове
        public int GoalsAgainst { get; set; } // Допуснати голове
        public int GoalDifference => GoalsFor - GoalsAgainst; // Голова разлика (изчислява се автоматично)

        // Препоръчителен формат за визуализация: "Вкарани : Допуснати"
        public string Goals => $"{GoalsFor}:{GoalsAgainst}";

        public int Points { get; set; } // Точки
    }
}