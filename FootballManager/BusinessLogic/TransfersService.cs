using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Data;

namespace FootballManager.BusinessLogic
{
    public class TransferService
    {
        private TransfersRepository _repository;

        public TransferService()
        {
            _repository = new TransfersRepository();
        }

        public DataTable GetClubsForDropdown() => _repository.GetClubsForDropdown();

        public DataTable GetPlayersForDropdown() => _repository.GetPlayersForDropdown();

        public DataTable GetTransfersHistory(int playerId) => _repository.GetTransfersHistory(playerId);

        // Изнасяме създаването на филтъра тук, за да не "цапаме" формата с манипулация на таблици
        public DataTable GetPlayersForFilter()
        {
            DataTable playersDt = _repository.GetPlayersForDropdown();

            DataTable playersFilterDt = new DataTable();
            playersFilterDt.Columns.Add("id", typeof(int));
            playersFilterDt.Columns.Add("full_name", typeof(string));

            playersFilterDt.Rows.Add(0, "Всички играчи");

            foreach (DataRow row in playersDt.Rows)
            {
                playersFilterDt.Rows.Add(row["id"], row["full_name"]);
            }

            return playersFilterDt;
        }

        // Основният метод за бизнес логика
        public void ExecuteTransfer(Transfer transfer)
        {
            ValidateTransfer(transfer);
            _repository.ExecuteTransfer(transfer);
        }

        // Централизирана бизнес валидация
        private void ValidateTransfer(Transfer transfer)
        {
            if (transfer.PlayerId <= 0)
                throw new ArgumentException("Невалиден играч!");

            if (transfer.ToClubId <= 0)
                throw new ArgumentException("Невалиден целеви клуб!");

            // ЗАДЪЛЖИТЕЛНА ВАЛИДАЦИЯ: Не може в същия клуб!
            if (transfer.FromClubId == transfer.ToClubId)
                throw new InvalidOperationException("Играчът вече е в този клуб! Трансферът е невъзможен.");

            if (transfer.TransferFee < 0)
                throw new ArgumentException("Трансферната сума не може да бъде отрицателна!");
        }
    }
}