select to_char(sysdate,'YYYY-MM-DD') from dual;

--Kik azok a dolgozók, akik 1982.01.01 után léptek be a céghez?
select dnev,belepes from dolgozo where belepes > TO_DATE('1982-01-01', 'YYYY-MM-DD');

--Kik azok a dolgozók, akiknek a jutaléka nem ismert? (vagyis NULL)
select dnev from dolgozo where jutalek is null;

--Minden dolgozó neve és jövedelme
select dnev Név, nvl(jutalek,0)+fizetes Jövedelem from dolgozo;

--Adjuk meg azon dolgozókat, akik nevének második betûje 'A'
select dnev from dolgozo where dnev like '_A%';
select dnev from dolgozo where substr(dnev,2,1) = 'A';

--Adjuk meg a dolgozók jövedelmét, osztva 12-vel
select dnev Név, round(((fizetes+nvl(jutalek,0)) / 12),2) "Havi jövedelem" from dolgozo;

--Adjuk meg azokat a (név, fõnök) párokat, ahol a két ember neve ugyanannyi betûbõl áll.
select * from dolgozo d1, dolgozo d2 where d1.dnev = d2.fonoke;
--and length(d2.dnev) = length(d1.dnev); 

--
SELECT dkod, dnev,
        (CASE
          WHEN fizetes >= 5000 THEN 'Magas'
          WHEN fizetes >= 3000 AND fizetes <= 5000 THEN 'Közepes'
          WHEN fizetes >= 1000 AND fizetes <  3000 THEN 'Átlagos'
          WHEN fizetes <   1000 THEN 'Alacsony'
          END) AS Fiz_Kat
          FROM dolgozo;


drop view fizkat;
--Adjuk meg azon osztályok nevét és telephelyét, amelyeknek van 1-es fizetési kategóriájú dolgozója.
create view FizKat as SELECT dkod, dnev, oazon,
        (CASE
          WHEN fizetes >= 5000 THEN 'Magas'
          WHEN fizetes >= 3000 AND fizetes <= 5000 THEN 'Közepes'
          WHEN fizetes >= 1000 AND fizetes <  3000 THEN 'Átlagos'
          WHEN fizetes <   1000 THEN 'Alacsony'
          END) AS Fiz_Kat
          FROM dolgozo;
          
select * from FIZKAT natural join OSZTALY
where FIZKAT.FIZ_KAT = 'Alacsony';

--Mekkora a maximális fizetés a dolgozók között
select max(fizetes) from dolgozo;
select round(avg(fizetes),2) from dolgozo; --átlag
select max(fizetes), dnev from dolgozo; -- error...
select max(fizetes),avg(fizetes) from dolgozo; -- ez pedig helyes (tetszõlegsen sok aggregáló fgv)
select oazon, max(fizetes),avg(fizetes) from dolgozo -- így már lehet
group by oazon;

select distinct oazon from dolgozo;

select oazon, max(fizetes),avg(fizetes) from dolgozo 
where oazon in (20,30)
group by oazon;

select oazon, max(fizetes),avg(fizetes) from dolgozo 
group by oazon
having oazon in (20,30); --sokszor ez optimálisabb megoldást biztosít

--SZORGALMI HÁZI FELADAT: feladat5.txt fájlban az utolsó két blokk feladat (1.6 számozás elõtt)