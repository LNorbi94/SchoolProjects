--Minden telephely, �tlagos fizet�ssel �s dolgoz�k sz�m�val
select round(avg(fizetes)), nvl(telephely,'Nincs telephely'), count(dkod) "Dolgoz�k sz�ma"
from dolgozo left outer join osztaly
on (dolgozo.oazon = osztaly.oazon)
group by telephely;




--olyan telephelyek ahol a dolgoz�k sz�ma nagyobb mint 3
select round(avg(fizetes)), nvl(telephely,'Nincs telephely'), count(dkod) "Dolgoz�k sz�ma"
from dolgozo left outer join osztaly
on (dolgozo.oazon = osztaly.oazon)
group by telephely having count(dkod) > 3 or count(dkod) = 1;

--Ugyan az outer join n�lk�l *******
select telephely, "�tlag fizet�s", "Dolgoz�k sz�ma"
from 
(select oazon, avg(fizetes) "�tlag fizet�s", count(dkod) "Dolgoz�k sz�ma"
from dolgozo
group by oazon
having count(dkod) > 3 or count(dkod) = 1) d1, osztaly o
where o.oazon = d1.oazon;

-- Adjuk meg oszt�lyonk�nt a legnagyobb j�vedelm? dolgoz�(ka)t, �s a j�vedelem (oazon, dnev, fizetes).
select onev "Oszt�ly n�v", dnev "Dolgoz� n�v",  fizetes+nvl(jutalek,0) "J�vedelem"
from dolgozo natural join osztaly
where (onev,fizetes+nvl(jutalek,0)) in
(select onev, max(fizetes+nvl(jutalek,0))
from dolgozo natural join osztaly
group by onev);

--Kik szeretnek minden gy�m�lcs�t
select count(distinct gyumolcs) from szeret;

--HF: + KIEFEJEZ�SFA!!!!!!!!!!!
/*1.6 p�lda (Kende M�ria-Nagy Istv�n: Oracle p�ldat�r - SQL, PL/SQL. Panem kiad�.)
List�zzuk ki a dolgoz�k nev�t �s fizet�s�t, valamint jelen�ts�k meg a fizet�st grafikusan
�gy, hogy a fizet�st 1000 Ft-ra kerek�tve, minden 1000 Ft-ot egy '#' jel jel�l.

1.8 p�lda
List�zzuk ki azoknak a dolgoz�knak a nev�t, fizet�s�t, jutal�k�t, �s a jutal�k/fizet�s
ar�ny�t, akiknek a foglalkoz�sa elad� (salesman). Az ar�nyt k�t tizedesen jelen�ts�k meg.

- Adjuk meg azon dolgoz�k nev�t, fizet�s�t, jutal�k�t, ad�s�vj�t �s fizetend� ad�j�t, akik
  nev�ben van S-bet�. Ad�s�vok 1000 alatt 0%, 1000 �s 2000 k�z�tt 20%, 2000 �s 3000 k�z�tt
  30%, 3000 f�l�tt 35%. Az ad�t a teljes jvedelemre (sal+comm) a megadott kulccsal kell fizetni.

2.17 feladat
K�sz�ts�nk list�t a p�ros �s p�ratlan azonos�t�j� dolgoz�k sz�m�r�l.

2.23 feladat
List�zzuk ki munkak�r�nk�nt a dolgoz�k sz�m�t, �tlagfizet�s�t (kerek�tve) numerikusan �s grafikusan is.
200-ank�nt jelen�ts�nk meg egy '#'-ot

3.7 feladat
List�zzuk ki minden r�szleg legkisebb j�vedelm� (sal+comm) dolgoz�j�nak nev�t, fizet�s�t, jutal�k�t.

3.8 feladat
List�zzuk ki azon r�szlegek nev�t �s telephely�t, ahol az �tlagj�vedelem (sal+comm) kisebb mint 2200.

ZH: Pap�ros r�sze hasonl� az els? zhhoz, kiterjesztett rel�ci�s kifejez�sek, 
    M�sodik r�sz, (g�pes) �sszetett SQL lek�rdez�sek)*/
    
    

--2016.03.31 Gyak
--DDL Data Definition Language
--Grant to public is kell
--CTAS Create Table as Select Csak a NOT NULL constraintetket viszi �t!!!!!!!!! a t�bbit k�zzel kell be�ll�tani
--t�bla m�sol�sa
drop table dolgozo2;
create table dolgozo2
as select * from dolgozo;

--drop table dolgozo3;
create table dolgozo3
as select * from dolgozo;
--constraintek hozz�ad�sa

--�j oszlop hozz�ad�sa
alter table dolgozo3 add (BONUSZ NUMBER(8,2));
alter table dolgozo3 modify (BONUSZ VARCHAR2(20));

--DML utas�t�s
-- az �sszes sorban updateli a bonusz mez?t , mert nincs where felt�tel
update dolgozo3 set bonusz2 = 2*FIZETES;-- + nvl(JUTALEK,0);

--m�r nem lehet m�dos�tani, csak n�velni ha sz�mr�l van sz�
alter table dolgozo3 modify (BONUSZ NUMBER(7,2));

alter table dolgozo3 rename column bonusz to bonusz2;

rollback; -- csak azokat a l�p�seket rollbackeli amelyeket DML utas�t�sokkal tett�nk, addig am�g nem volt DDL utas�t�s

alter table dolgozo3 drop column bonusz2;

