set serveroutput on

-- 1. feladat
CREATE OR REPLACE PROCEDURE borrow IS
  v_count number;
  v_kazon integer;
BEGIN
   FOR v_rec IN (SELECT * FROM ig�nyl�s) LOOP
     SELECT count(*) INTO v_count FROM �gyf�l WHERE igazolv�nysz�m = v_rec.igazolv�nysz�m;
     IF v_count = 0 THEN
       dbms_output.put_line('Nincs ilyen igazolv�nysz�m.');
     ELSE
       SELECT count(*) INTO v_count FROM kazetta WHERE fazon = v_rec.fazon;
       IF v_count = 0 THEN
         dbms_output.put_line('Nincs ilyen film azonos�t�.');
       ELSE
         SELECT count(*) INTO v_count FROM film WHERE fazon = v_rec.fazon;
         IF v_count = 0 THEN
           dbms_output.put_line('M�r minden filmet kik�lcs�n�ztek.');
         ELSE
           SELECT kazon INTO v_kazon FROM kazetta NATURAL JOIN film WHERE fazon = v_rec.fazon;
           INSERT INTO k�lcs�nz�s (igazolv�nysz�m, kazon, elvitel_d�tuma) VALUES (v_rec.igazov�nysz�m, v_kazon, SYSDATE);
           DELETE FROM ig�nyl�s WHERE fazon = v_rec.fazon and igazolv�nysz�m = v_rec.igazolv�nysz�m;
         END IF;
       END IF;
     END IF;
   END LOOP;
END;
/

-- 3. feladat
CREATE OR REPLACE TYPE movies AS TABLE OF VARCHAR2(20);
/

CREATE OR REPLACE FUNCTION costMovies(c integer) RETURN movies IS
  ret movies;
  i integer := 0;
BEGIN
   FOR v_rec IN (SELECT igazolv�nsz�m, c�m FROM
   �gyf�l NATURAL JOIN k�lcs�nz�s NATURAL JOIN kazetta NATURAL JOIN film
   WHERE igazolv�nysz�m = c) LOOP
   ret.extend(1);
   ret(i) := v_rec.c�m;
   i := i + 1;
   END LOOP;
   RETURN ret;
END;
/

-- 2. feladat
CREATE OR REPLACE PROCEDURE back(n varchar2, i integer) IS
  v_kazon integer;
BEGIN
  NULL;
  SELECT kazon into v_kazon FROM k�lcs�nz�s NATURAL JOIN kazetta NATURAL JOIN film WHERE c�m = n AND igazolv�nysz�m = i;
  IF v_kazon > 0 THEN
    dbms_output.put_line(v_kazon);
    DELETE FROM k�lcs�nz�s WHERE kazon = v_kazon;
  END IF;
  costMovies(i);
END;
/

-- 4. feladat
CREATE OR REPLACE PROCEDURE costumersWithT IS
BEGIN
   FOR v_rec IN (SELECT n�v FROM (
                  SELECT n�v, count(kazon) as kszam FROM
                  (�gyf�l NATURAL JOIN k�lcs�nz�s NATURAL JOIN kazetta) GROUP BY n�v)
                  WHERE kszam >= 3) LOOP
   dbms_output.put_line(v_rec.n�v);
   END LOOP;
END;
/

-- 5. feladat
CREATE OR REPLACE TRIGGER t
  BEFORE
    INSERT OR
    UPDATE OR
    DELETE
  ON k�lcs�nz�s
  FOR EACH ROW
BEGIN
  CASE
    WHEN INSERTING THEN
      INSERT INTO napl� (d�tum, m�velet, userx, kazon) VALUES (SYSDATE, 'Besz�r�s', :OLD.igazolv�nysz�m, :OLD.kazon);
    WHEN UPDATING THEN
      INSERT INTO napl� (d�tum, m�velet, userx, kazon) VALUES (SYSDATE, 'Friss�t�s', :OLD.igazolv�nysz�m, :OLD.kazon);
    WHEN DELETING THEN
      INSERT INTO napl� (d�tum, m�velet, userx, kazon) VALUES (SYSDATE, 'T�rl�s', :OLD.igazolv�nysz�m, :OLD.kazon);
  END CASE;
END;
/

-- 6. feladat
CREATE OR REPLACE FUNCTION hanyszor(p1 VARCHAR2, p2 VARCHAR2) RETURN integer IS
  num INTEGER := -1;
  pos INTEGER := -1;
BEGIN
  WHILE pos != 0 LOOP
    IF pos = -1 OR pos = 1 THEN
      pos := pos + 1;
    END IF;
    pos := INSTRB(p1, p2, pos + 1, 1);
    num := num + 1;
  END LOOP;
  RETURN num;
END;
/