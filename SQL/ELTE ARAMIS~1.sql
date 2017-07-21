set serveroutput on;
declare 

function f_fact(N Number) return Number is
begin
  if N = 0 then
    return 1;
  else
    return N * f_fact(N-1);
  end if;
end;

begin

DBMS_OUTPUT.PUT_LINE(f_fact(21));
end;