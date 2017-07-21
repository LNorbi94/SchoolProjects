set serveroutput on;
declare
/*v_name varchar2(40);
v_income number;
v_currency varchar2(4);*/

cursor c_mycursor IS
        select 'Összjövedelem/osztály: ' "query_name",
        sum( fizetes + nvl(jutalek,0)) "income",'$' "currency", onev 
        from dolgozo natural join osztaly
        group by onev;
  c_row c_mycursor%rowtype;

begin

open c_mycursor;
loop
  fetch c_mycursor into c_row;
  exit when c_mycursor%notfound;
  DBMS_OUTPUT.PUT_LINE(c_row."query_name"|| c_row."income" || c_row."currency" || ' osztály: ' || c_row.onev);

  
end loop;

close c_mycursor;
/*select 'Összjövedelem/osztály: ' "query_name",
        sum( fizetes + nvl(jutalek,0)) "income",'$' "currency", onev 
        into v_name,v_income,v_currency
from dolgozo natural join osztaly
group by onev having onev like 'cc';*/


/*FOR I IN (select 'Összjövedelem/osztály: ' "query_name",
        sum( fizetes + nvl(jutalek,0)) "income",'$' "currency", onev 
        from dolgozo natural join osztaly
        group by onev)
        LOOP
    DBMS_OUTPUT.PUT_LINE(I."query_name"|| I."income" || I."currency" || ' osztály: ' || I.onev);
END LOOP;*/

--Cursorral ugyanez



--SYS.DBMS_OUTPUT.PUT_LINE(v_name || v_income || v_currency);
end;