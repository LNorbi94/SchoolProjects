set serveroutput on

-- 1. feladat
CREATE OR REPLACE PROCEDURE borrow IS
  v_count number;
  v_kazon integer;
BEGIN
   FOR v_rec IN (SELECT * FROM igénylés) LOOP
     SELECT count(*) INTO v_count FROM ügyfél WHERE igazolványszám = v_rec.igazolványszám;
     IF v_count = 0 THEN
       dbms_output.put_line('Nincs ilyen igazolványszám.');
     ELSE
       SELECT count(*) INTO v_count FROM kazetta WHERE fazon = v_rec.fazon;
       IF v_count = 0 THEN
         dbms_output.put_line('Nincs ilyen film azonosító.');
       ELSE
         SELECT count(*) INTO v_count FROM film WHERE fazon = v_rec.fazon;
         IF v_count = 0 THEN
           dbms_output.put_line('Már minden filmet kikölcsönöztek.');
         ELSE
           SELECT kazon INTO v_kazon FROM kazetta NATURAL JOIN film WHERE fazon = v_rec.fazon;
           INSERT INTO kölcsönzés (igazolványszám, kazon, elvitel_dátuma) VALUES (v_rec.igazoványszám, v_kazon, SYSDATE);
           DELETE FROM igénylés WHERE fazon = v_rec.fazon and igazolványszám = v_rec.igazolványszám;
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
   FOR v_rec IN (SELECT igazolvánszám, cím FROM
   ügyfél NATURAL JOIN kölcsönzés NATURAL JOIN kazetta NATURAL JOIN film
   WHERE igazolványszám = c) LOOP
   ret.extend(1);
   ret(i) := v_rec.cím;
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
  SELECT kazon into v_kazon FROM kölcsönzés NATURAL JOIN kazetta NATURAL JOIN film WHERE cím = n AND igazolványszám = i;
  IF v_kazon > 0 THEN
    dbms_output.put_line(v_kazon);
    DELETE FROM kölcsönzés WHERE kazon = v_kazon;
  END IF;
  costMovies(i);
END;
/

-- 4. feladat
CREATE OR REPLACE PROCEDURE costumersWithT IS
BEGIN
   FOR v_rec IN (SELECT név FROM (
                  SELECT név, count(kazon) as kszam FROM
                  (ügyfél NATURAL JOIN kölcsönzés NATURAL JOIN kazetta) GROUP BY név)
                  WHERE kszam >= 3) LOOP
   dbms_output.put_line(v_rec.név);
   END LOOP;
END;
/

-- 5. feladat
CREATE OR REPLACE TRIGGER t
  BEFORE
    INSERT OR
    UPDATE OR
    DELETE
  ON kölcsönzés
  FOR EACH ROW
BEGIN
  CASE
    WHEN INSERTING THEN
      INSERT INTO napló (dátum, mûvelet, userx, kazon) VALUES (SYSDATE, 'Beszúrás', :OLD.igazolványszám, :OLD.kazon);
    WHEN UPDATING THEN
      INSERT INTO napló (dátum, mûvelet, userx, kazon) VALUES (SYSDATE, 'Frissítés', :OLD.igazolványszám, :OLD.kazon);
    WHEN DELETING THEN
      INSERT INTO napló (dátum, mûvelet, userx, kazon) VALUES (SYSDATE, 'Törlés', :OLD.igazolványszám, :OLD.kazon);
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