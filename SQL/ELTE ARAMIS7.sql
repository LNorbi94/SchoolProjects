set SERVEROUTPUT ON
declare 

  cursor c_emel(p_nev VARCHAR2) is
    select dkod,dnev,fizetes 
    from dolgozo where dnev like '%'||p_nev||'%'
    FOR UPDATE ; --%p_nev% -- FOR UPDATE MIATT 
    
  c_rec c_emel%ROWTYPE;
    
begin
  open c_emel('A');
  loop
    fetch c_emel into c_rec;
      exit when c_emel%NOTFOUND;
      --Innen kez?dik a t�rzs
      update dolgozo
      set fizetes = 1.2*c_rer.fizetes
      --where dkod=c_rec.dkod; --rossz megold�s NEM EZT HASZN�LJUK!!!!!
      where current of c_emel; -- FOR UPDATE MIATT CSAK AZ AKTU�LUS SORT M�DOS�TJA!!
      DBMS_OUTPUT.PUT_LINE(c_rec.dnev || ' ' || c_rec.fizetes);
      
  end loop;
  
  close c_emel;


end;