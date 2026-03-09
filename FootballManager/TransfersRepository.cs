using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FootballManager
{
    public class TransfersRepository
    {
        // 1. Взимане на играчи за падащото меню (с техния текущ клуб)
        public DataTable GetPlayersForDropdown()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"SELECT p.id, CONCAT(p.first_name, ' ', p.last_name) AS full_name, 
                                        p.current_club_id, IFNULL(c.name, 'Свободен агент') AS current_club_name
                                 FROM players p
                                 LEFT JOIN clubs c ON p.current_club_id = c.id
                                 ORDER BY p.first_name";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 2. Взимане на клубове за падащото меню
        public DataTable GetClubsForDropdown()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT id, name FROM clubs ORDER BY name";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 3. Извличане на историята (с JOIN за красиви имена) + Филтър по играч
        public DataTable GetTransfersHistory(int playerIdFilter)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                // ПРОМЯНА: t.transfer_fee и премахнат t.note
                string query = @"SELECT t.id, t.transfer_date AS 'Дата', 
                                        CONCAT(p.first_name, ' ', p.last_name) AS 'Играч',
                                        IFNULL(fc.name, 'Свободен агент') AS 'От Клуб',
                                        tc.name AS 'В Клуб',
                                        t.transfer_fee AS 'Сума (€)'
                                 FROM transfers t
                                 JOIN players p ON t.player_id = p.id
                                 LEFT JOIN clubs fc ON t.from_club_id = fc.id
                                 JOIN clubs tc ON t.to_club_id = tc.id
                                 WHERE 1=1 ";

                if (playerIdFilter > 0) query += " AND t.player_id = @PlayerId";

                query += " ORDER BY t.transfer_date DESC";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (playerIdFilter > 0) command.Parameters.AddWithValue("@PlayerId", playerIdFilter);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 4. ДОБАВЯНЕ НА ТРАНСФЕР (ТРАНЗАКЦИЯ: Запис + Обновяване на играча)
        public void ExecuteTransfer(Transfer transfer)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // СТЪПКА 1: Записваме в таблицата transfers
                        string insertQuery = @"INSERT INTO transfers (player_id, from_club_id, to_club_id, transfer_date, transfer_fee) 
                                               VALUES (@PlayerId, @FromClubId, @ToClubId, @TransferDate, @TransferFee)";
                        using (var cmdInsert = new MySqlCommand(insertQuery, connection, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@PlayerId", transfer.PlayerId);
                            cmdInsert.Parameters.AddWithValue("@FromClubId", transfer.FromClubId.HasValue ? (object)transfer.FromClubId.Value : DBNull.Value);
                            cmdInsert.Parameters.AddWithValue("@ToClubId", transfer.ToClubId);
                            cmdInsert.Parameters.AddWithValue("@TransferDate", transfer.TransferDate);
                            cmdInsert.Parameters.AddWithValue("@TransferFee", transfer.TransferFee);

                            cmdInsert.ExecuteNonQuery();
                        }

                        // СТЪПКА 2: Обновяваме играча (сменяме му клуба)
                        string updateQuery = "UPDATE players SET current_club_id = @ToClubId WHERE id = @PlayerId";
                        using (var cmdUpdate = new MySqlCommand(updateQuery, connection, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@ToClubId", transfer.ToClubId);
                            cmdUpdate.Parameters.AddWithValue("@PlayerId", transfer.PlayerId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Трансферът пропадна: " + ex.Message);
                    }
                }
            }
        }
    }
}