USE football_manager;

-- 1. Списък на всички регистрирани грандове
SELECT name, stadium, founded_year FROM clubs ORDER BY founded_year;

-- 2. Търсене на всички нападатели (FW) в базата
SELECT first_name, last_name, nationality, kit_number 
FROM players 
WHERE position = 'FW';

-- 3. Кой в кой отбор играе? (Join заявка)
SELECT 
    p.first_name, 
    p.last_name, 
    c.name AS Club_Name
FROM players p
JOIN clubs c ON p.current_club_id = c.id
ORDER BY c.name;

-- 4. Резултати от изиграни мачове
SELECT 
    m.match_date,
    hc.name AS Home,
    ac.name AS Away,
    CONCAT(m.home_goals, '-', m.away_goals) AS Score
FROM matches m
JOIN clubs hc ON m.home_club_id = hc.id
JOIN clubs ac ON m.away_club_id = ac.id
WHERE m.status = 'Played';

-- 5. Голмайстори в дербито Manchester City vs Arsenal (Match ID 1)
SELECT 
    p.last_name AS Scorer,
    c.name AS Team,
    g.goal_minute
FROM goals g
JOIN players p ON g.player_id = p.id
JOIN clubs c ON p.current_club_id = c.id
WHERE g.match_id = 1
ORDER BY g.goal_minute;

-- 6. Справка: Играчи под 25 години
SELECT first_name, last_name, birth_date 
FROM players 
WHERE birth_date > '2001-01-01';