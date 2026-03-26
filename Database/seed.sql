USE football_manager;

-- --------------------------------------------------------
-- 1. ПОТРЕБИТЕЛИ
-- --------------------------------------------------------
INSERT INTO users (username, password_hash, role) VALUES 
('admin', 'hashed_password_123', 'Admin'),
('referee', 'hashed_password_456', 'Operator');

-- --------------------------------------------------------
-- 2. КЛУБОВЕ (IDs: 1 до 6)
-- --------------------------------------------------------
INSERT INTO clubs (name, city, stadium, founded_year) VALUES 
('Real Madrid', 'Madrid', 'Santiago Bernabeu', 1902),
('FC Barcelona', 'Barcelona', 'Camp Nou', 1899),
('Manchester City', 'Manchester', 'Etihad Stadium', 1880),
('Arsenal FC', 'London', 'Emirates Stadium', 1886),
('Liverpool FC', 'Liverpool', 'Anfield', 1892),
('Bayern Munich', 'Munich', 'Allianz Arena', 1900);

-- --------------------------------------------------------
-- 3. ЛИГИ (IDs: 1 до 4)
-- --------------------------------------------------------
INSERT INTO leagues (name, season) VALUES 
('La Liga', '2025/2026'),
('Premier League', '2025/2026'),
('Bundesliga', '2025/2026'),
('Champions League', '2025/2026');

-- --------------------------------------------------------
-- 4. УЧАСТНИЦИ В ЛИГИТЕ (Много-към-много)
-- --------------------------------------------------------
INSERT INTO league_teams (league_id, club_id) VALUES 
-- La Liga
(1, 1), (1, 2),
-- Premier League
(2, 3), (2, 4), (2, 5),
-- Bundesliga
(3, 6),
-- Champions League (Всички топ отбори участват)
(4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6);

-- --------------------------------------------------------
-- 5. ИГРАЧИ (С реални дати на раждане и позиции)
-- --------------------------------------------------------
INSERT INTO players (first_name, last_name, birth_date, position, nationality, kit_number, current_club_id) VALUES
-- Real Madrid (Club ID 1)
('Thibaut', 'Courtois', '1992-05-11', 'GK', 'Belgium', 1, 1),
('Antonio', 'Rudiger', '1993-03-03', 'DF', 'Germany', 22, 1),
('Dani', 'Carvajal', '1992-01-11', 'DF', 'Spain', 2, 1),
('Jude', 'Bellingham', '2003-06-29', 'MF', 'England', 5, 1),
('Luka', 'Modric', '1985-09-09', 'MF', 'Croatia', 10, 1),
('Vinicius', 'Junior', '2000-07-12', 'FW', 'Brazil', 7, 1),
('Kylian', 'Mbappe', '1998-12-20', 'FW', 'France', 9, 1),
('Rodrygo', 'Goes', '2001-01-09', 'FW', 'Brazil', 11, 1),

-- FC Barcelona (Club ID 2)
('Marc-Andre', 'ter Stegen', '1992-04-30', 'GK', 'Germany', 1, 2),
('Ronald', 'Araujo', '1999-03-07', 'DF', 'Uruguay', 4, 2),
('Jules', 'Kounde', '1998-11-12', 'DF', 'France', 23, 2),
('Pedri', 'Gonzalez', '2002-11-25', 'MF', 'Spain', 8, 2),
('Gavi', 'Paez', '2004-08-05', 'MF', 'Spain', 6, 2),
('Lamine', 'Yamal', '2007-07-13', 'FW', 'Spain', 19, 2),
('Robert', 'Lewandowski', '1988-08-21', 'FW', 'Poland', 9, 2),
('Raphinha', 'Dias', '1996-12-14', 'FW', 'Brazil', 11, 2),

-- Manchester City (Club ID 3)
('Ederson', 'Moraes', '1993-08-17', 'GK', 'Brazil', 31, 3),
('Ruben', 'Dias', '1997-05-14', 'DF', 'Portugal', 3, 3),
('John', 'Stones', '1994-05-28', 'DF', 'England', 5, 3),
('Rodri', 'Cascante', '1996-06-22', 'MF', 'Spain', 16, 3),
('Kevin', 'De Bruyne', '1991-06-28', 'MF', 'Belgium', 17, 3),
('Bernardo', 'Silva', '1994-08-10', 'MF', 'Portugal', 20, 3),
('Phil', 'Foden', '2000-05-28', 'MF', 'England', 47, 3),
('Erling', 'Haaland', '2000-07-21', 'FW', 'Norway', 9, 3),

-- Arsenal FC (Club ID 4)
('David', 'Raya', '1995-09-15', 'GK', 'Spain', 22, 4),
('William', 'Saliba', '2001-03-24', 'DF', 'France', 2, 4),
('Ben', 'White', '1997-10-08', 'DF', 'England', 4, 4),
('Declan', 'Rice', '1999-01-14', 'MF', 'England', 41, 4),
('Martin', 'Odegaard', '1998-12-17', 'MF', 'Norway', 8, 4),
('Bukayo', 'Saka', '2001-09-05', 'FW', 'England', 7, 4),
('Gabriel', 'Martinelli', '2001-06-18', 'FW', 'Brazil', 11, 4),
('Gabriel', 'Jesus', '1997-04-03', 'FW', 'Brazil', 9, 4),

-- Liverpool FC (Club ID 5)
('Alisson', 'Becker', '1992-10-02', 'GK', 'Brazil', 1, 5),
('Virgil', 'van Dijk', '1991-07-08', 'DF', 'Netherlands', 4, 5),
('Trent', 'Alexander-Arnold', '1998-10-07', 'DF', 'England', 66, 5),
('Alexis', 'Mac Allister', '1998-12-24', 'MF', 'Argentina', 10, 5),
('Dominik', 'Szoboszlai', '2000-10-25', 'MF', 'Hungary', 8, 5),
('Mohamed', 'Salah', '1992-06-15', 'FW', 'Egypt', 11, 5),
('Luis', 'Diaz', '1997-01-13', 'FW', 'Colombia', 7, 5),
('Darwin', 'Nunez', '1999-06-24', 'FW', 'Uruguay', 9, 5),

-- Bayern Munich (Club ID 6)
('Manuel', 'Neuer', '1986-03-27', 'GK', 'Germany', 1, 6),
('Dayot', 'Upamecano', '1998-10-27', 'DF', 'France', 2, 6),
('Alphonso', 'Davies', '2000-11-02', 'DF', 'Canada', 19, 6),
('Joshua', 'Kimmich', '1995-02-08', 'MF', 'Germany', 6, 6),
('Jamal', 'Musiala', '2003-02-26', 'MF', 'Germany', 42, 6),
('Leroy', 'Sane', '1996-01-11', 'FW', 'Germany', 10, 6),
('Thomas', 'Muller', '1989-09-13', 'FW', 'Germany', 25, 6),
('Harry', 'Kane', '1993-07-28', 'FW', 'England', 9, 6),

-- Свободен агент (ID 49) - Тестване на NULL за current_club_id
('Paul', 'Pogba', '1993-03-15', 'MF', 'France', 10, NULL);


-- --------------------------------------------------------
-- 6. ТРАНСФЕРИ (История на реални трансфери между тези отбори)
-- --------------------------------------------------------
INSERT INTO transfers (player_id, from_club_id, to_club_id, transfer_date, transfer_fee) VALUES
-- Габриел Жезус: Ман Сити (3) -> Арсенал (4)
(32, 3, 4, '2022-07-04', 52200000.00),

-- Лерой Сане: Ман Сити (3) -> Байерн Мюнхен (6)
(46, 3, 6, '2020-07-03', 49000000.00),

-- Килиан Мбапе: Свободен агент (NULL) -> Реал Мадрид (1)
(7, NULL, 1, '2024-07-01', 0.00),

-- Хари Кейн: Свободен агент (NULL, идва от Тотнъм извън базата) -> Байерн (6)
(48, NULL, 6, '2023-08-12', 95000000.00);
