using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Data;

namespace FootballManager.BusinessLogic
{
    public class MatchResultService
    {
        private MatchResultRepository _repository;

        public MatchResultService()
        {
            _repository = new MatchResultRepository();
        }

        // Методи за извличане на данни
        public DataTable GetMatchesForDropdown() => _repository.GetMatchesForDropdown();

        public DataTable GetPlayersForMatch(int matchId) => _repository.GetPlayersForMatch(matchId);

        public DataTable GetMatchEvents(int matchId) => _repository.GetMatchEvents(matchId);

        // Основен метод за добавяне на събитие
        public void AddEvent(MatchEvent matchEvent)
        {
            ValidateEvent(matchEvent);

            // Предполагаме, че Repository методът приема параметрите така, според оригиналния ти код
            _repository.AddEvent(matchEvent.MatchId, matchEvent.PlayerId, matchEvent.ClubId, matchEvent.EventType, matchEvent.Minute);
        }

        // Централизирана валидация
        private void ValidateEvent(MatchEvent matchEvent)
        {
            if (matchEvent.MatchId <= 0)
                throw new ArgumentException("Изберете валиден мач!");

            if (matchEvent.PlayerId <= 0)
                throw new ArgumentException("Изберете валиден играч!");

            if (string.IsNullOrWhiteSpace(matchEvent.EventType))
                throw new ArgumentException("Изберете тип на събитието!");

            if (matchEvent.Minute < 1 || matchEvent.Minute > 120)
                throw new ArgumentException("Минутата трябва да е между 1 и 120!");
        }
    }
}