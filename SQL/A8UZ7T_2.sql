-- 1. feladat
CREATE TABLE visszahoz AS (SELECT * FROM branyi.berles WHERE EXTRACT(year FROM datum) = EXTRACT(year FROM SYSDATE));

-- 2. feladat
ALTER TABLE visszahoz ADD megtettut INTEGER;

-- 3. feldat
UPDATE visszahoz SET megtettut = 10 WHERE hazon IN (SELECT hazon FROM branyi.berles natural join branyi.csonak WHERE tipus = 'Katamarán' AND szin <> 'kék');
UPDATE visszahoz SET megtettut = 9 WHERE hazon IN (SELECT hazon FROM branyi.berles natural join branyi.csonak WHERE tipus = 'Katamarán' AND szin = 'kék');
UPDATE visszahoz SET megtettut = 20 WHERE hazon IN
(SELECT hazon FROM branyi.berles natural join branyi.csonak WHERE (tipus = 'Marine' OR tipus = 'Interlake') AND tartam < 5);
UPDATE visszahoz SET megtettut = 17 WHERE hazon IN
(SELECT hazon FROM branyi.berles natural join branyi.csonak WHERE (tipus = 'Marine' OR tipus = 'Interlake') AND tartam >= 5);

-- 4. feladat
SELECT nev, MAX(tartam) FROM branyi.hajos natural join branyi.berles GROUP BY nev;

-- 5. feladat
SELECT RPAD(tipus, 25 - LENGTH(szin) + LENGTH(tipus), '.') || szin FROM branyi.csonak;

-- 6. feladat
SELECT nev FROM branyi.hajos WHERE kor < (SELECT AVG(kor) FROM branyi.hajos natural join branyi.berles WHERE csazon = 66 GROUP BY nev);

-- 7. feladat
SELECT DISTINCT nev FROM branyi.hajos NATURAL JOIN branyi.berles WHERE EXTRACT(month FROM datum) = 12
MINUS
SELECT DISTINCT nev FROM branyi.hajos NATURAL JOIN branyi.berles WHERE EXTRACT(month FROM datum) != 12;

-- 8. feladat
SELECT csazon FROM branyi.berles NATURAL JOIN branyi.csonak WHERE MOD(TO_CHAR(datum, 'J'), 7) + 1 = 1;

-- 9. feladat
CREATE TABLE berletidij (
  MAXIDO INTEGER NOT NULL PRIMARY KEY,
  ingyenkm INTEGER NOT NULL,
  extrakmdij INTEGER NOT NULL
);
INSERT INTO berletidij VALUES (1, 6, 100);
INSERT INTO berletidij VALUES (3, 25, 70);
INSERT INTO berletidij VALUES (7, 80, 50);
INSERT INTO berletidij VALUES (30, 600, 20);

-- 10. feladat

WITH berlet AS(
  SELECT * FROM (visszahoz NATURAL JOIN branyi.hajos), berletidij WHERE MAXIDO 
)
SELECT nev, datum FROM visszahoz NATURAL JOIN branyi.hajos;
