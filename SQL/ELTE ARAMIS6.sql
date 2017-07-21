--factorial declared as procedure
set serveroutput on;

declare
  l_e INT := 1;

  /*procedure p_fact(v_n INT, v_result IN OUT INT) is
  begin
    if v_n > 1 then
      v_result := v_n * v_result;
      p_fact(v_n-1,v_result);
    end if;
  end p_fact;*/
  
begin
  p_fact(5,l_e);
  DBMS_OUTPUT.put_line(l_e);
end;