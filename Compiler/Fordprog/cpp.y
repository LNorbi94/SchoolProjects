%baseclass-preinclude "semantics.h"
%lsp-needed

%union
{
    std::string* name;
    type*        var_type;
}

%token  LBRACE
%token  RBRACE
%token  INT
%token  MAIN
%token  UNSIGNED
%token  BOOL
%token  TRUE
%token  FALSE
%token  IF
%token  ELSE
%token  WHILE
%token  COUT
%token  CIN
%token  OPEN
%token  CLOSE
%token  WRITE
%token  READ
%token  ASSIGNMENT
%token  SEMICOLON
%token  NUMBER

%token  <name> VARIABLE
%type   <var_type> expression

%left   AND
%left   OR
%right  NOT
%left   EQUAL
%left   SMALLER BIGGER
%left   PLUS MINUS
%left   MULTIPLY DIV MOD

%%

start:
    INT MAIN OPEN CLOSE LBRACE declarations instructions RBRACE
;

declarations:
    // empty
|
    declaration declarations
;

declaration:
    UNSIGNED VARIABLE SEMICOLON
    {
        if (symbolTable.count(*$2) > 0)
        {
            std::stringstream ss;
            ss  << "Ujradeklaralt valtozo: " << *$2 << "." << std::endl
                << "Korabbi deklaracio sora: " << symbolTable[*$2].decl_row << std::endl;
            error (ss.str().c_str());
        } else
        {
            symbolTable[*$2] = var_data (d_loc__.first_line, number);
        }
    }
|
    BOOL VARIABLE SEMICOLON
    {
        if (symbolTable.count(*$2) > 0)
        {
            std::stringstream ss;
            ss  << "Ujradeklaralt valtozo: " << *$2 << "." << std::endl
                << "Korabbi deklaracio sora: " << symbolTable[*$2].decl_row << std::endl;
            error (ss.str().c_str());
        } else
        {
            symbolTable[*$2] = var_data (d_loc__.first_line, boolean);
        }
    }
;

instructions:
    instruction
|
    instruction instructions
;

instruction:
    assign
|
    in
|
    out
|
    branching
|
    cycle
;

assign:
    VARIABLE ASSIGNMENT expression SEMICOLON
    {
        if (symbolTable.count(*$1) < 1)
        {
            std::stringstream ss;
            ss  << "Nem deklaralt valtozo: " << *$1 << "." << std::endl;
            error (ss.str().c_str());
        }
        else if (symbolTable[*$1].var_type != *$3)
        {
            error( "Tipushibas ertekadas.\n" );
        }
        delete $1;
        delete $3;
    }
;

in:
    CIN READ VARIABLE SEMICOLON
    {
        if (symbolTable.count(*$3) < 1)
        {
            std::stringstream ss;
            ss  << "Nem deklaralt valtozo: " << *$3 << "." << std::endl;
            error (ss.str().c_str());
        }
        delete $3;
    }
;

out:
    COUT WRITE expression SEMICOLON
;

branching:
    IF OPEN expression CLOSE LBRACE instructions RBRACE
    {
        if (*$3 != boolean)
        {
            std::stringstream ss;
            ss  << "Nem logikai kifejezes: " << *$3 << "." << std::endl;
            error (ss.str().c_str());
        }
        delete $3;
    }
|
    IF OPEN expression CLOSE LBRACE instructions RBRACE ELSE LBRACE instructions RBRACE
    {
        if (*$3 != boolean)
        {
            std::stringstream ss;
            ss  << "Nem logikai kifejezes: " << *$3 << "." << std::endl;
            error (ss.str().c_str());
        }
        delete $3;
    }
;

cycle:
    WHILE OPEN expression CLOSE LBRACE instructions RBRACE
    {
        if (*$3 != boolean)
        {
            std::stringstream ss;
            ss  << "Nem logikai kifejezes: " << *$3 << "." << std::endl;
            error (ss.str().c_str());
        }
        delete $3;
    }
;

expression:
    NUMBER
    {
        $$ = new type(number);
    }
|
    TRUE
    {
        $$ = new type(boolean);
    }
|
    FALSE
    {
        $$ = new type(boolean);
    }
|
    VARIABLE
    {
        if (symbolTable.count(*$1) > 0)
        {
            $$ = new type(symbolTable[*$1].var_type);
        } else
        {
            std::stringstream ss;
            ss  << "Nem deklaralt valtozo: " << *$1 << "." << std::endl;
            error (ss.str().c_str());
        }
    }
|
    expression AND expression
    {
        if ((*$1 == *$3) && *$3 == boolean)
        {
            $$ = new type(boolean);
        } else
        {
            error( "Csak logikai kifejezeseket lehet osszeeselni!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression OR expression
    {
        if ((*$1 == *$3) && *$3 == boolean)
        {
            $$ = new type(boolean);
        } else
        {
            error( "Csak logikai kifejezeseket lehet osszevagyolni!\n" );
        }
        delete $1;
        delete $3;
    }
|
    NOT expression
    {
        if (*$2 == boolean)
        {
            $$ = new type(boolean);
        }
        else
        {
            std::stringstream ss;
            ss  << "Nem logikai kifejezes: " << *$2 << "." << std::endl;
            error (ss.str().c_str());
        }
        delete $2;
    }
|
    expression EQUAL expression
    {
        if (*$1 == *$3)
        {
            $$ = new type(boolean);
        } else
        {
            error( "Csak azonos tipusu kifejezeseket lehet osszehasonlitani!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression SMALLER expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(boolean);
        } else
        {
            error( "Csak szamokat lehet osszehasonlitani!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression BIGGER expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(boolean);
        } else
        {
            error( "Csak szamokat lehet osszehasonlitani!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression PLUS expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(number);
        } else
        {
            error( "Csak szamokat lehet osszeadni!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression MINUS expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(number);
        } else
        {
            error( "Csak szamokat lehet kivonni!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression MULTIPLY expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(number);
        } else
        {
            error( "Csak szamokat lehet szorozni!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression DIV expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(number);
        } else
        {
            error( "Csak szamokat lehet osztani!\n" );
        }
        delete $1;
        delete $3;
    }
|
    expression MOD expression
    {
        if ((*$1 == *$3) && *$3 == number)
        {
            $$ = new type(number);
        } else
        {
            error( "Csak szamokat lehet maradekosan osztani!\n" );
        }
        delete $1;
        delete $3;
    }
|
    OPEN expression CLOSE
    {
        $$ = new type(*$2);
    }
;