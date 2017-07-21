--Minden telephely, átlagos fizetéssel és dolgozók számával
select round(avg(fizetes)), nvl(telephely,'Nincs telephely'), count(dkod) "Dolgozók száma"
from dolgozo left outer join osztaly
on (dolgozo.oazon = osztaly.oazon)
group by telephely;




--olyan telephelyek ahol a dolgozók száma nagyobb mint 3
select round(avg(fizetes)), nvl(telephely,'Nincs telephely'), count(dkod) "Dolgozók száma"
from dolgozo left outer join osztaly
on (dolgozo.oazon = osztaly.oazon)
group by telephely having count(dkod) > 3 or count(dkod) = 1;

--Ugyan az outer join nélkül *******
select telephely, "Átlag fizetés", "Dolgozók száma"
from 
(select oazon, avg(fizetes) "Átlag fizetés", count(dkod) "Dolgozók száma"
from dolgozo
group by oazon
having count(dkod) > 3 or count(dkod) = 1) d1, osztaly o
where o.oazon = d1.oazon;

-- Adjuk meg osztályonként a legnagyobb jövedelm? dolgozó(ka)t, és a jövedelem (oazon, dnev, fizetes).
select onev "Osztály név", dnev "Dolgozó név",  fizetes+nvl(jutalek,0) "Jövedelem"
from dolgozo natural join osztaly
where (onev,fizetes+nvl(jutalek,0)) in
(select onev, max(fizetes+nvl(jutalek,0))
from dolgozo natural join osztaly
group by onev);

--Kik szeretnek minden gyümölcsöt
select count(distinct gyumolcs) from szeret;

--HF: + KIEFEJEZÉSFA!!!!!!!!!!!
/*1.6 példa (Kende Mária-Nagy István: Oracle példatár - SQL, PL/SQL. Panem kiadó.)
Listázzuk ki a dolgozók nevét és fizetését, valamint jelenítsük meg a fizetést grafikusan
úgy, hogy a fizetést 1000 Ft-ra kerekítve, minden 1000 Ft-ot egy '#' jel jelöl.

1.8 példa
Listázzuk ki azoknak a dolgozóknak a nevét, fizetését, jutalékát, és a jutalék/fizetés
arányát, akiknek a foglalkozása eladó (salesman). Az arányt két tizedesen jelenítsük meg.

- Adjuk meg azon dolgozók nevét, fizetését, jutalékát, adósávját és fizetendõ adóját, akik
  nevében van S-betû. Adósávok 1000 alatt 0%, 1000 és 2000 között 20%, 2000 és 3000 között
  30%, 3000 fölött 35%. Az adót a teljes jvedelemre (sal+comm) a megadott kulccsal kell fizetni.

2.17 feladat
Készítsünk listát a páros és páratlan azonosítójú dolgozók számáról.

2.23 feladat
Listázzuk ki munkakörönként a dolgozók számát, átlagfizetését (kerekítve) numerikusan és grafikusan is.
200-anként jelenítsünk meg egy '#'-ot

3.7 feladat
Listázzuk ki minden részleg legkisebb jövedelmû (sal+comm) dolgozójának nevét, fizetését, jutalékát.

3.8 feladat
Listázzuk ki azon részlegek nevét és telephelyét, ahol az átlagjövedelem (sal+comm) kisebb mint 2200.

ZH: Papíros része hasonló az els? zhhoz, kiterjesztett relációs kifejezések, 
    Második rész, (gépes) összetett SQL lekérdezések)*/
    
    

--2016.03.31 Gyak
--DDL Data Definition Language
--Grant to public is kell
--CTAS Create Table as Select Csak a NOT NULL constraintetket viszi át!!!!!!!!! a többit kézzel kell beállítani
--tábla másolása
drop table dolgozo2;
create table dolgozo2
as select * from dolgozo;

--drop table dolgozo3;
create table dolgozo3
as select * from dolgozo;
--constraintek hozzáadása

--új oszlop hozzáadása
alter table dolgozo3 add (BONUSZ NUMBER(8,2));
alter table dolgozo3 modify (BONUSZ VARCHAR2(20));

--DML utasítás
-- az összes sorban updateli a bonusz mez?t , mert nincs where feltétel
update dolgozo3 set bonusz2 = 2*FIZETES;-- + nvl(JUTALEK,0);

--már nem lehet módosítani, csak növelni ha számról van szó
alter table dolgozo3 modify (BONUSZ NUMBER(7,2));

alter table dolgozo3 rename column bonusz to bonusz2;

rollback; -- csak azokat a lépéseket rollbackeli amelyeket DML utasításokkal tettünk, addig amíg nem volt DDL utasítás

alter table dolgozo3 drop column bonusz2;

