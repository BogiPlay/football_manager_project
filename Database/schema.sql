-- Създаване на базата данни (ако не съществува)
CREATE DATABASE IF NOT EXISTS football_manager;
USE football_manager;

-- 1. Таблица за потребители и роли
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin', 'Operator', 'User') NOT NULL DEFAULT 'User'
);

-- 2. Таблица за лиги/първенства
CREATE TABLE leagues (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    season VARCHAR(20) NOT NULL,
    CONSTRAINT uq_league_season UNIQUE (name, season) -- Забранява дублиране на лига за един и същи сезон
);

CREATE TABLE league_teams (
    league_id INT NOT NULL,
    club_id INT NOT NULL,
    PRIMARY KEY (league_id, club_id),
    CONSTRAINT fk_lt_league FOREIGN KEY (league_id) REFERENCES leagues(id) ON DELETE RESTRICT, 
    CONSTRAINT fk_lt_club FOREIGN KEY (club_id) REFERENCES clubs(id) ON DELETE RESTRICT
);

-- 3. Таблица за клубове
CREATE TABLE clubs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    city VARCHAR(50),
    stadium VARCHAR(100),
    founded_year INT
);

-- 4. Таблица за играчи
CREATE TABLE players (
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

-- 5. Таблица за трансфери (История)
CREATE TABLE transfers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    from_club_id INT,
    to_club_id INT NOT NULL,
    transfer_date DATE NOT NULL,
    transfer_fee DECIMAL(15, 2) DEFAULT 0,
    CONSTRAINT fk_trans_player FOREIGN KEY (player_id) REFERENCES players(id),
    CONSTRAINT fk_trans_from FOREIGN KEY (from_club_id) REFERENCES clubs(id),
    CONSTRAINT fk_trans_to FOREIGN KEY (to_club_id) REFERENCES clubs(id)
);

-- 6. Таблица за мачове
CREATE TABLE matches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    league_id INT NOT NULL,
    home_club_id INT NOT NULL,
    away_club_id INT NOT NULL,
    match_date DATETIME NOT NULL,
    round INT NOT NULL, -- Номер на кръг
    home_goals INT DEFAULT 0,
    away_goals INT DEFAULT 0,
    status ENUM('Scheduled', 'Played', 'Postponed') DEFAULT 'Scheduled',
    CONSTRAINT fk_match_league FOREIGN KEY (league_id) REFERENCES leagues(id),
    CONSTRAINT fk_match_home FOREIGN KEY (home_club_id) REFERENCES clubs(id),
    CONSTRAINT fk_match_away FOREIGN KEY (away_club_id) REFERENCES clubs(id),
    CONSTRAINT check_teams CHECK (home_club_id <> away_club_id) -- Валидация: отбор не може да играе срещу себе си
);

-- 7. Таблица за голове
CREATE TABLE goals (
    id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    goal_minute INT NOT NULL,
    is_own_goal BOOLEAN DEFAULT FALSE,
    CONSTRAINT fk_goal_match FOREIGN KEY (match_id) REFERENCES matches(id) ON DELETE CASCADE,
    CONSTRAINT fk_goal_player FOREIGN KEY (player_id) REFERENCES players(id),
    CONSTRAINT check_goal_minute CHECK (goal_minute BETWEEN 1 AND 120) -- Валидация за минута
);

-- 8. Таблица за картони
CREATE TABLE cards (
    id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    card_type ENUM('Yellow', 'Red') NOT NULL,
    card_minute INT NOT NULL,
    CONSTRAINT fk_card_match FOREIGN KEY (match_id) REFERENCES matches(id) ON DELETE CASCADE,
    CONSTRAINT fk_card_player FOREIGN KEY (player_id) REFERENCES players(id)
);
