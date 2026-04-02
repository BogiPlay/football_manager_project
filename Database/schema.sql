CREATE DATABASE IF NOT EXISTS football_manager;
USE football_manager;

-- 1. Таблица за клубове (Етап 2)
CREATE TABLE IF NOT EXISTS clubs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    city VARCHAR(50),
    stadium VARCHAR(100),
    founded_year INT
);

-- 2. Таблица за играчи (Етап 3)
CREATE TABLE IF NOT EXISTS players (
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    birth_date DATE NOT NULL,
    position ENUM('GK', 'DF', 'MF', 'FW') NOT NULL,
    nationality VARCHAR(50),
    kit_number INT,
    current_club_id INT,
    CONSTRAINT fk_player_club FOREIGN KEY (current_club_id) REFERENCES clubs(id) ON DELETE SET NULL
);

-- 3. Таблица за история на трансферите (Етап 4)
CREATE TABLE IF NOT EXISTS transfers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    from_club_id INT,
    to_club_id INT NOT NULL,
    transfer_date DATE NOT NULL,
    transfer_fee DECIMAL(15, 2) DEFAULT 0,
    CONSTRAINT fk_trans_player FOREIGN KEY (player_id) REFERENCES players(id) ON DELETE CASCADE,
    CONSTRAINT fk_trans_from FOREIGN KEY (from_club_id) REFERENCES clubs(id) ON DELETE SET NULL,
    CONSTRAINT fk_trans_to FOREIGN KEY (to_club_id) REFERENCES clubs(id) ON DELETE CASCADE
);

-- 4. Таблица за първенства / лиги (Етап 5)
CREATE TABLE IF NOT EXISTS leagues (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    season VARCHAR(20) NOT NULL,
    CONSTRAINT uq_league_season UNIQUE (name, season)
);

-- 5. Таблица за участници в лигата (Етап 5) - МНОГО КЪМ МНОГО
CREATE TABLE IF NOT EXISTS league_teams (
    league_id INT NOT NULL,
    club_id INT NOT NULL,
    PRIMARY KEY (league_id, club_id),
    CONSTRAINT fk_lt_league FOREIGN KEY (league_id) REFERENCES leagues(id) ON DELETE RESTRICT, 
    CONSTRAINT fk_lt_club FOREIGN KEY (club_id) REFERENCES clubs(id) ON DELETE RESTRICT
);

-- 6. Таблица за мачове и програма (Етап 6)
CREATE TABLE IF NOT EXISTS matches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    league_id INT NOT NULL,
    round_no INT NOT NULL,
    home_club_id INT NOT NULL,
    away_club_id INT NOT NULL,
    match_date DATETIME,
    status ENUM('Scheduled', 'Played', 'Postponed') DEFAULT 'Scheduled',
    home_goals INT DEFAULT 0,
    away_goals INT DEFAULT 0,
    CONSTRAINT fk_match_league FOREIGN KEY (league_id) REFERENCES leagues(id) ON DELETE CASCADE,
    CONSTRAINT fk_match_home FOREIGN KEY (home_club_id) REFERENCES clubs(id) ON DELETE CASCADE,
    CONSTRAINT fk_match_away FOREIGN KEY (away_club_id) REFERENCES clubs(id) ON DELETE CASCADE,
    CONSTRAINT chk_different_clubs CHECK (home_club_id != away_club_id) -- Отбор не може да играе със себе си
);

-- 7. Таблица за голове (Етап 7)
CREATE TABLE IF NOT EXISTS goals (
    id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    club_id INT NOT NULL, -- За да знаем за кой отбор е голът
    goal_minute INT NOT NULL CHECK (goal_minute BETWEEN 1 AND 120), -- Валидация за минута
    CONSTRAINT fk_goal_match FOREIGN KEY (match_id) REFERENCES matches(id) ON DELETE CASCADE,
    CONSTRAINT fk_goal_player FOREIGN KEY (player_id) REFERENCES players(id) ON DELETE CASCADE,
    CONSTRAINT fk_goal_club FOREIGN KEY (club_id) REFERENCES clubs(id) ON DELETE CASCADE
);

-- 8. Таблица за картони (Етап 7)
CREATE TABLE IF NOT EXISTS cards (
    id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    card_type ENUM('Yellow', 'Red') NOT NULL,
    card_minute INT NOT NULL CHECK (card_minute BETWEEN 1 AND 120),
    CONSTRAINT fk_card_match FOREIGN KEY (match_id) REFERENCES matches(id) ON DELETE CASCADE,
    CONSTRAINT fk_card_player FOREIGN KEY (player_id) REFERENCES players(id) ON DELETE CASCADE
);

-- 9. Таблица за нарушения (фалове) (Етап 7)
CREATE TABLE IF NOT EXISTS fouls (
    id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    foul_type VARCHAR(50) DEFAULT 'Обикновен фал',
    foul_minute INT NOT NULL CHECK (foul_minute BETWEEN 1 AND 120),
    CONSTRAINT fk_foul_match FOREIGN KEY (match_id) REFERENCES matches(id) ON DELETE CASCADE,
    CONSTRAINT fk_foul_player FOREIGN KEY (player_id) REFERENCES players(id) ON DELETE CASCADE
);

-- (По желание) Таблица за потребители/роли (От Етап 1)
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin', 'Operator', 'User') NOT NULL DEFAULT 'User'
);
