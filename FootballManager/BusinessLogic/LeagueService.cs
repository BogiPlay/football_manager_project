using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Data;
using MySql.Data.MySqlClient; // Добавяме тук, за да хващаме DB грешките на това ниво

namespace FootballManager.BusinessLogic
{
    public class LeagueService
    {
        private LeaguesRepository _repository;

        public LeagueService()
        {
            _repository = new LeaguesRepository();
        }

        public DataTable GetAllLeagues() => _repository.GetAllLeagues();

        public DataTable GetParticipants(int leagueId) => _repository.GetParticipants(leagueId);

        public DataTable GetAvailableClubs(int leagueId) => _repository.GetAvailableClubs(leagueId);

        // CRUD операции за Лига
        public void AddLeague(League league)
        {
            ValidateLeague(league);
            try
            {
                _repository.AddLeague(league);
            }
            catch (MySqlException ex) when (ex.Number == 1062) // UNIQUE constraint
            {
                throw new InvalidOperationException("Лига с това име и сезон вече съществува!");
            }
        }

        public void UpdateLeague(League league)
        {
            ValidateLeague(league);
            try
            {
                _repository.UpdateLeague(league);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new InvalidOperationException("Лига с това име и сезон вече съществува!");
            }
        }

        public void DeleteLeague(int id)
        {
            try
            {
                _repository.DeleteLeague(id);
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Foreign Key constraint
            {
                throw new InvalidOperationException("Тази лига не може да бъде изтрита, защото в нея има записани отбори!");
            }
        }

        // Операции за управление на участниците
        public void AddClubToLeague(int leagueId, int clubId)
        {
            if (leagueId == 0 || clubId == 0)
                throw new ArgumentException("Невалидна лига или клуб.");

            _repository.AddClubToLeague(leagueId, clubId);
        }

        public void RemoveClubFromLeague(int leagueId, int clubId)
        {
            if (leagueId == 0 || clubId == 0)
                throw new ArgumentException("Невалидна лига или клуб.");

            _repository.RemoveClubFromLeague(leagueId, clubId);
        }

        // Централизирана валидация
        private void ValidateLeague(League league)
        {
            if (string.IsNullOrWhiteSpace(league.Name) || string.IsNullOrWhiteSpace(league.Season))
                throw new ArgumentException("Името и сезонът са задължителни!");
        }
    }
}