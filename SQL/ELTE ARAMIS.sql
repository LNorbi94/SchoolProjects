select nev from szeret where gyumolcs = (select gyumolcs from szeret where nev = 'Micimackó');

SELECT DISTINCT sz1.nev FROM szeret sz1, (SELECT * FROM szeret WHERE nev='Micimackó') sz2 WHERE sz1.gyumolcs = sz2.gyumolcs AND sz1.nev != 'Micimackó';

SELECT * FROM szeret;

SELECT nev FROM SZERET WHERE gyumolcs='alma' MINUS SELECT S1.nev FROM szeret S1, SZERET S2 WHERE S1.NEV = S2.NEV AND S1.GYUMOLCS='alma' AND S2.GYUMOLCS='körte';

SELECT DISTINCT S1.NEV FROM SZERET S1, SZERET S2 WHERE S1.NEV = S2.NEV AND S1.GYUMOLCS != S2.GYUMOLCS;

SELECT DISTINCT S1.NEV FROM SZERET S1, SZERET S2, SZERET S3 WHERE S1.NEV = S2.NEV AND S1.NEV = S3.NEV AND S1.GYUMOLCS != S2.GYUMOLCS AND S1.GYUMOLCS != S3.GYUMOLCS;

SELECT DISTINCT S1.NEV FROM SZERET S1, SZERET S2, SZERET S3 WHERE S1.NEV = S2.NEV AND S2.NEV=S3.NEV AND S1.GYUMOLCS != S2.GYUMOLCS AND S1.GYUMOLCS != S3.GYUMOLCS AND S2.GYUMOLCS != S3.GYUMOLCS;

SELECT * FROM SZERET SZ1;--, SZERET SZ2;

INSERT INTO SZERET VALUES ('Macika','körte');--,'Macika','dinnye','Macika','körte');

select * from (select nev from szeret), (select gyumolcs from szeret) minus (select * from szeret);


select nev from szeret minus select nev from ( select * from (select nev from szeret), (select gyumolcs from szeret) minus (select * from szeret));

--13.as
SELECT nev FROM szeret sz1 MINUS (SELECT sz2.nev FROM szeret sz1, ((SELECT DISTINCT * FROM (SELECT nev from szeret) n, (SELECT gyumolcs from szeret) gy)  MINUS (SELECT * FROM szeret)) sz2 WHERE sz1.nev='Micimackó' and sz1.gyumolcs=sz2.gyumolcs);

select * from szeret;

--14.
select nev from szeret where nev != 'Micimackó' minus select sz2.nev from (select distinct * from (select nev from szeret), (select gyumolcs from szeret) MINUS select * from szeret) sz1, szeret sz2 WHERE sz1.nev='Micimackó' and sz1.gyumolcs = sz2.gyumolcs;

--15
(SELECT nev FROM szeret sz1 MINUS (SELECT sz2.nev FROM szeret sz1, ((SELECT DISTINCT * FROM (SELECT nev from szeret) n, (SELECT gyumolcs from szeret) gy)  MINUS (SELECT * FROM szeret)) sz2 WHERE sz1.nev='Micimackó' and sz1.gyumolcs=sz2.gyumolcs))
INTERSECT
(select nev from szeret where nev != 'Micimackó' minus select sz2.nev from (select distinct * from (select nev from szeret), (select gyumolcs from szeret) MINUS select * from szeret) sz1, szeret sz2 WHERE sz1.nev='Micimackó' and sz1.gyumolcs = sz2.gyumolcs);


select * from szeret, ((select * from (select nev from szeret), (select gyumolcs from szeret)) minus (select * from szeret));



select distinct * from szeret, (select * from (select nev from szeret), (select gyumolcs from szeret)) ;

--14.es roossz
select nev from szeret where nev!='Micimackó' minus (select nev from szeret minus select nev from szeret where gyumolcs IN (select gyumolcs from szeret where nev='Micimackó'));

-- van olyan gyümölcse amit micimackó nem szeret
select distinct nev from szeret where gyumolcs not IN (select gyumolcs from szeret where nev='Micimackó');

select * from szeret sz1,(select distinct * from (select nev from szeret), (select gyumolcs from szeret) MINUS select * from szeret) sz2;





--- 3. Gyakorlat










