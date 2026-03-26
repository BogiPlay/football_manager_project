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

-- (По желание) Таблица за потребители/роли (От Етап 1)
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin', 'Operator', 'User') NOT NULL DEFAULT 'User'
);
