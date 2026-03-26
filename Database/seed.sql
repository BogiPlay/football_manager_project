USE football_manager;

-- 1. Добавяне на примерен администратор
INSERT INTO users (username, password_hash, role) VALUES 
('admin', 'admin123_hash', 'Admin'),
('operator', 'pass123', 'Operator');

-- 2. Добавяне на лига
INSERT INTO leagues (name, season) VALUES 
('Първа лига', '2025/2026'),
('Втора лига', '2025/2026'),
('Шампионска лига', '2025/2026');

-- Записване на отбори (ако приемем, че имат ID 1, 2, 3 и 4 от Етап 2)
INSERT INTO league_teams (league_id, club_id) VALUES 
(1, 1), (1, 2), (1, 3), -- 3 отбора в Първа лига
(3, 1), (3, 4);         -- 2 отбора в Шампионска лига (един клуб може да е в 2 лиги)

-- 3. Добавяне на известни клубове
INSERT INTO clubs (name, city, stadium, founded_year) VALUES 
('Manchester City', 'Manchester', 'Etihad Stadium', 1880),
('Arsenal', 'London', 'Emirates Stadium', 1886),
('Liverpool', 'Liverpool', 'Anfield', 1892),
('Real Madrid', 'Madrid', 'Santiago Bernabéu', 1902);

-- 4. Добавяне на играчи (С точни дати на раждане)
INSERT INTO players (first_name, last_name, birth_date, position, nationality, kit_number, current_club_id) VALUES
-- Manchester City (Club ID 1)
('Erling', 'Haaland', '2000-07-21', 'FW', 'Norway', 9, 1),
('Kevin', 'De Bruyne', '1991-06-28', 'MF', 'Belgium', 17, 1),
('Ruben', 'Dias', '1997-05-14', 'DF', 'Portugal', 3, 1),

-- Arsenal (Club ID 2)
('Bukayo', 'Saka', '2001-09-05', 'FW', 'England', 7, 2),
('Martin', 'Odegaard', '1998-12-17', 'MF', 'Norway', 8, 2),
('William', 'Saliba', '2001-03-24', 'DF', 'France', 2, 2),

-- Liverpool (Club ID 3)
('Mohamed', 'Salah', '1992-06-15', 'FW', 'Egypt', 11, 3),
('Virgil', 'van Dijk', '1991-07-08', 'DF', 'Netherlands', 4, 3),
('Alisson', 'Becker', '1992-10-02', 'GK', 'Brazil', 1, 3),

-- Real Madrid (Club ID 4)
('Kylian', 'Mbappe', '1998-12-20', 'FW', 'France', 9, 4),
('Jude', 'Bellingham', '2003-06-29', 'MF', 'England', 5, 4),
('Thibaut', 'Courtois', '1992-05-11', 'GK', 'Belgium', 1, 4);

-- 5. Добавяне на мачове
-- Мач 1: Man City vs Arsenal (Изигран, зрелищно 2:2)
INSERT INTO matches (league_id, home_club_id, away_club_id, match_date, round, home_goals, away_goals, status) VALUES
(1, 1, 2, '2024-09-22 18:30:00', 5, 2, 2, 'Played');

-- Мач 2: Liverpool vs Real Madrid (Предстоящ)
INSERT INTO matches (league_id, home_club_id, away_club_id, match_date, round, home_goals, away_goals, status) VALUES
(1, 3, 4, '2024-11-27 22:00:00', 5, 0, 0, 'Scheduled');

-- 6. Добавяне на събития за Мач 1 (Man City 2 : 2 Arsenal)
-- Гол на Haaland (City) в 9-та минута
INSERT INTO goals (match_id, player_id, goal_minute) VALUES (1, 1, 9);

-- Гол на Calafiori (Арсенал) - тъй като не го добавихме горе, ще пишем гола на Gabriel (защитник, нека кажем Saliba за теста) или ще добавим Saka
-- Нека Saka вкара
INSERT INTO goals (match_id, player_id, goal_minute) VALUES (1, 4, 22); 

-- Още един гол за Арсенал (Gabriel не е в списъка, нека пишем на Odegaard за теста)
INSERT INTO goals (match_id, player_id, goal_minute) VALUES (1, 5, 45);

-- Изравнителен гол на Stones (City) - няма го в списъка, нека пишем на De Bruyne за теста
INSERT INTO goals (match_id, player_id, goal_minute) VALUES (1, 2, 98);

-- Картони
-- Жълт картон за Trossard (Arsenal) -> пишем на Saliba
INSERT INTO cards (match_id, player_id, card_type, card_minute) VALUES (1, 6, 'Yellow', 34);
-- Жълт картон за Haaland
INSERT INTO cards (match_id, player_id, card_type, card_minute) VALUES (1, 1, 'Yellow', 99);
