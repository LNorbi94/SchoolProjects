select dnev from dolgozo
where dnev='sda'
MINUS
select unique d1.dnev from dolgozo d1, dolgozo  d2
where d1.dkod = d2.fonoke;