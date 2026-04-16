using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Data;

namespace FootballManager.BusinessLogic
{
    public class ClubService
    {
        private ClubsRepository _repository;

        public ClubService()
        {
            _repository = new ClubsRepository();
        }

        // Взимане на данните
        public DataTable GetAllClubs() => _repository.GetAllClubs();

        // CRUD операции с бизнес валидация
        public void AddClub(Club club)
        {
            ValidateClub(club);
            _repository.AddClub(club);
        }

        public void UpdateClub(Club club)
        {
            ValidateClub(club);
            _repository.UpdateClub(club);
        }

        public void DeleteClub(int id)
        {
            _repository.DeleteClub(id);
        }

        // Централизирана валидация за клубове
        private void ValidateClub(Club club)
        {
            if (string.IsNullOrWhiteSpace(club.Name))
                throw new ArgumentException("Името на клуба е задължително!");

            // Допълнителна бизнес логика: Годината да не е в бъдещето (опционално, но препоръчително)
            if (club.FoundedYear > DateTime.Now.Year)
                throw new ArgumentException("Годината на основаване не може да бъде в бъдещето!");

            if (club.FoundedYear < 1850 && club.FoundedYear != 0) // 1857 е най-старият клуб (Шефилд)
                throw new ArgumentException("Въведена е невалидна година на основаване!");
        }
    }
}