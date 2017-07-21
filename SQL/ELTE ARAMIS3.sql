set serveroutput on;
DECLARE
v_rows_deleted VARCHAR2(30);
v_oazon dolgozo2.oazon%TYPE := NULL;
BEGIN
DELETE FROM dolgozo2
WHERE oazon = v_oazon;
v_rows_deleted := (SQL%ROWCOUNT || ' row(s) deleted.');
DBMS_OUTPUT.PUT_LINE (v_rows_deleted);
END;

DECLARE v_dkod dolgozo.dkod%TYPE;-- := 7902;
--DECLARE v_dnev dolgozo.dnev%TYPE;

BEGIN


FOR I IN (SELECT dnev,dkod,onev INTO 
FROM DOLGOZO natural join OSZTALY 
            WHERE dkod = &v_dkod) LOOP
      DBMS_OUTPUT.PUT_LINE(I.dnev || ':' || I.dkod || ':' || I.onev);
END LOOP;
END;