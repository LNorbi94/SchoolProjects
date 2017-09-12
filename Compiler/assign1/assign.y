%baseclass-preinclude "semantics.h"
%lsp-needed

%union
{
    std::string* szoveg;
    type* varType;
}

%token NUMBER;
%token NATURAL;
%token BOOLEAN;
%token TRUE;
%token FALSE;
%token <szoveg> IDENT;
%token ASSIGN;

%type<varType> exp

%%

start:
    declarations assignments
;

declarations:
    // ures
|
    declaration declarations
;

declaration:
    NATURAL IDENT
    {
        if( szimbolumtabla.count(*$2) > 0 )
        {
            std::stringstream ss;
            ss << "Ujradeklaralt valtozo: " << *$2 << ".\n"
            << "Korabbi deklaracio sora: " << szimbolumtabla[*$2].decl_row << std::endl;
            error( ss.str().c_str() );
        } else {
            szimbolumtabla[*$2] = var_data( d_loc__.first_line, natural );
        }
    }
|
    BOOLEAN IDENT
    {
        if( szimbolumtabla.count(*$2) > 0 )
        {
            std::stringstream ss;
            ss << "Ujradeklaralt valtozo: " << *$2 << ".\n"
            << "Korabbi deklaracio sora: " << szimbolumtabla[*$2].decl_row << std::endl;
            error( ss.str().c_str() );
        } else {
            szimbolumtabla[*$2] = var_data( d_loc__.first_line, boolean );
        }
    }
;

assignments:
    // ures
|
    assignment assignments
;

assignment:
    IDENT ASSIGN expr
    {
        if( szimbolumtabla[*$1].var_type != *($3.varType) )
        {
            error( "Tipushibas ertekadas.\n" );
        }
    }
;

expr:
    IDENT
    {
        $$.varType = new type(szimbolumtabla[*$1].var_type);
    }
|
    NUMBER
    {
        $$.varType = new type(natural);
    }
|
    TRUE
    {
        $$.varType = new type(boolean);
    }
|
    FALSE
    {
        $$.varType = new type(boolean);
    }
;
