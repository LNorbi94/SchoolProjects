set SERVEROUTPUT ON
declare 

  cursor c_raise is
    select dnev,dkod,fizetes,jutalek 
    from dolgozo
    order by dnev,dkod
    FOR UPDATE ;
    
    
    v_temp dologoz.dnev%TYPE;
  c_rec c_raise%ROWTYPE;
  v_i INTEGER := 0;
  
  FONOK_WITHOUT_EMPLOYEE EXCEPTION;
begin
  open c_raise;
  loop
    fetch c_raise into c_rec;
      exit when c_raise%NOTFOUND;
      --BODY
      v_i := v_i+1;
      
      if mod(v_i,2) = 0
      then
        select dnev from dolgozo
            where dnev=c_rec.dnev
            MINUS
            select unique d1.dnev from dolgozo d1, dolgozo  d2
            where d1.dkod = d2.fonoke; --ha f?nök akkor üres lista ha nem akkor egy sor
        
        if(SQL%FOUND) --ha beosztott
        then 
          update dolgozo
          set jutalek = jutalek + 0.4*c_rec.fizetes
           where current of c_raise;
        end if;
        
        select d1.dnev from dolgozo d1, dolgozo  d2
            where d1.dkod = d2.fonoke and d1.dnev = rec.dnev; --ha f?nök egyet ad vissza ha nem 0t
            
        if(SQL%ROWCOUNT > 2) --ha f?nök és kett?nél több beoszottja van
        then 
          update dolgozo
          set jutalek = jutalek + 1.2*c_rec.fizetes
           where current of c_raise;
        elsif(SQL%ROWCOUNT <= 2 AND SQL%ROWCOUNT >= 1)
        then
          update dolgozo
           set jutalek = jutalek + 0.8*c_rec.fizetes
            where current of c_raise;
       /* else
          raise FONOK_WITHOUT_EMPLOYEE;*/
        end if;
        
      end if;
      
  end loop;
  
  close c_raise;


end;