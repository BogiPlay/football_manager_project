using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Data;

namespace FootballManager.BusinessLogic
{
    public class PlayerService
    {
        private PlayersRepository _repository;

        public PlayerService()
        {
            _repository = new PlayersRepository();
        }

        // Прехвърляне на данните за таблиците/падащите менюта
        public DataTable GetClubsForDropdown() => _repository.GetClubsForDropdown();

        public DataTable GetPlayers(int clubId, string position, string search) =>
            _repository.GetPlayers(clubId, position, search);

        // CRUD операции с вградена валидация
        public void AddPlayer(Player p)
        {
            ValidatePlayer(p);
            _repository.AddPlayer(p);
        }

        public void UpdatePlayer(Player p)
        {
            ValidatePlayer(p);
            _repository.UpdatePlayer(p);
        }

        public void DeletePlayer(int id)
        {
            _repository.DeletePlayer(id);
        }

        // Бизнес логиката за валидация се мести тук
        private void ValidatePlayer(Player p)
        {
            if (string.IsNullOrWhiteSpace(p.FirstName) || string.IsNullOrWhiteSpace(p.LastName))
                throw new ArgumentException("Името и фамилията са задължителни!");

            if (string.IsNullOrWhiteSpace(p.Position))
                throw new ArgumentException("Моля, изберете валидна позиция (GK, DF, MF, FW)!");

            int age = DateTime.Today.Year - p.BirthDate.Year;
            if (p.BirthDate.Date > DateTime.Today.AddYears(-age)) age--;

            if (age < 10 || age > 60)
                throw new ArgumentException("Възрастта на играча трябва да е между 10 и 60 години!");
        }
    }
}