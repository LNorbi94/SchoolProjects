select to_char(sysdate,'YYYY-MM-DD') from dual;

--Kik azok a dolgoz�k, akik 1982.01.01 ut�n l�ptek be a c�ghez?
select dnev,belepes from dolgozo where belepes > TO_DATE('1982-01-01', 'YYYY-MM-DD');

--Kik azok a dolgoz�k, akiknek a jutal�ka nem ismert? (vagyis NULL)
select dnev from dolgozo where jutalek is null;

--Minden dolgoz� neve �s j�vedelme
select dnev N�v, nvl(jutalek,0)+fizetes J�vedelem from dolgozo;

--Adjuk meg azon dolgoz�kat, akik nev�nek m�sodik bet�je 'A'
select dnev from dolgozo where dnev like '_A%';
select dnev from dolgozo where substr(dnev,2,1) = 'A';

--Adjuk meg a dolgoz�k j�vedelm�t, osztva 12-vel
select dnev N�v, round(((fizetes+nvl(jutalek,0)) / 12),2) "Havi j�vedelem" from dolgozo;

--Adjuk meg azokat a (n�v, f�n�k) p�rokat, ahol a k�t ember neve ugyanannyi bet�b�l �ll.
select * from dolgozo d1, dolgozo d2 where d1.dnev = d2.fonoke;
--and length(d2.dnev) = length(d1.dnev); 

--
SELECT dkod, dnev,
        (CASE
          WHEN fizetes >= 5000 THEN 'Magas'
          WHEN fizetes >= 3000 AND fizetes <= 5000 THEN 'K�zepes'
          WHEN fizetes >= 1000 AND fizetes <  3000 THEN '�tlagos'
          WHEN fizetes <   1000 THEN 'Alacsony'
          END) AS Fiz_Kat
          FROM dolgozo;


drop view fizkat;
--Adjuk meg azon oszt�lyok nev�t �s telephely�t, amelyeknek van 1-es fizet�si kateg�ri�j� dolgoz�ja.
create view FizKat as SELECT dkod, dnev, oazon,
        (CASE
          WHEN fizetes >= 5000 THEN 'Magas'
          WHEN fizetes >= 3000 AND fizetes <= 5000 THEN 'K�zepes'
          WHEN fizetes >= 1000 AND fizetes <  3000 THEN '�tlagos'
          WHEN fizetes <   1000 THEN 'Alacsony'
          END) AS Fiz_Kat
          FROM dolgozo;
          
select * from FIZKAT natural join OSZTALY
where FIZKAT.FIZ_KAT = 'Alacsony';

--Mekkora a maxim�lis fizet�s a dolgoz�k k�z�tt
select max(fizetes) from dolgozo;
select round(avg(fizetes),2) from dolgozo; --�tlag
select max(fizetes), dnev from dolgozo; -- error...
select max(fizetes),avg(fizetes) from dolgozo; -- ez pedig helyes (tetsz�legsen sok aggreg�l� fgv)
select oazon, max(fizetes),avg(fizetes) from dolgozo -- �gy m�r lehet
group by oazon;

select distinct oazon from dolgozo;

select oazon, max(fizetes),avg(fizetes) from dolgozo 
where oazon in (20,30)
group by oazon;

select oazon, max(fizetes),avg(fizetes) from dolgozo 
group by oazon
having oazon in (20,30); --sokszor ez optim�lisabb megold�st biztos�t

--SZORGALMI H�ZI FELADAT: feladat5.txt f�jlban az utols� k�t blokk feladat (1.6 sz�moz�s el�tt)