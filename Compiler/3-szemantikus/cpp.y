%baseclass-preinclude "semantics.h"

%lsp-needed

%token INT
%token MAIN
%token KEZDES
%token VEGE
%token EGESZ 
%token LOGIKAI
%token FIXPONTOS
%token HA
%token KULONBEN
%token AMIG
%token OLVAS
%token IR
%token EGESZRESZ
%token TORTRESZ
%token KIMENET
%token BEMENET
%token PONTOSVESSZO
%token ERTEKADAS
%token BALZAROJEL
%token JOBBZAROJEL
%token <szoveg> SZAM
%token <szoveg> FIXPONTOSSZAM
%token IGAZ
%token HAMIS
%token <szoveg> AZONOSITO

%left VAGY
%left ES
%left NEM
%left EGYENLO
%left KISEBB NAGYOBB
%left PLUSZ MINUSZ
%left SZORZAS OSZTAS MARADEK

%type <kif> kifejezes
%type <utasitas> ertekadas
%type <utasitas> be
%type <utasitas> ki
%type <utasitas> elagazas
%type <utasitas> ciklus

%union
{
    std::string *szoveg;
    kifejezes_leiro *kif;
    utasitas_leiro *utasitas;
}

%%

start:
    INT MAIN BALZAROJEL JOBBZAROJEL KEZDES deklaraciok utasitasok VEGE
    {
    }
;

deklaraciok:
    // ures
    {
    }
|
    deklaracio deklaraciok
    {
    }
;

deklaracio:
    EGESZ AZONOSITO PONTOSVESSZO
    {
        if( szimb_tabla.count(*$2) > 0 )
        {
            std::cerr << d_loc__.first_line << ".: A(z) '" << *$2 << "' valtozo mar definialva volt a "
            << szimb_tabla[*$2].def_sora << ". sorban." << std::endl;
            exit(1);
        }
        else
        {
            szimb_tabla[*$2] = valtozo_leiro(d_loc__.first_line,Egesz);
        }
        delete $2;
    }
|
    LOGIKAI AZONOSITO PONTOSVESSZO
    {
        if( szimb_tabla.count(*$2) > 0 )
        {
            std::cerr << d_loc__.first_line << ".: A(z) '" << *$2 << "' valtozo mar definialva volt a "
            << szimb_tabla[*$2].def_sora << ". sorban." << std::endl;
            exit(1);
        }
        else
        {
            szimb_tabla[*$2] = valtozo_leiro(d_loc__.first_line,Logikai);
        }
        delete $2;
    }
|
    FIXPONTOS AZONOSITO PONTOSVESSZO
    {
        if( szimb_tabla.count(*$2) > 0 )
        {
            std::cerr << d_loc__.first_line << ".: A(z) '" << *$2 << "' valtozo mar definialva volt a "
            << szimb_tabla[*$2].def_sora << ". sorban." << std::endl;
            exit(1);
        }
        else
        {
            szimb_tabla[*$2] = valtozo_leiro(d_loc__.first_line, Fixpontos);
        }
        delete $2;
    }
;

utasitasok:
    utasitas
    {
    }
|
    utasitas utasitasok
    {
    }
;

utasitas:
    ertekadas
    {
    }
|
    be
    {
    }
|
    ki
    {
    }
|
    elagazas
    {
    }
|
    ciklus
    {
    }
;

ertekadas:
    AZONOSITO ERTEKADAS kifejezes PONTOSVESSZO
    {
        if( szimb_tabla.count( *$1 ) == 0 )
        {
            std::cerr << d_loc__.first_line << ": A(z) '" << *$1 << "' valtozo nincs deklaralva." << std::endl;
            exit(1);
        }
        else if( szimb_tabla[*$1].vtip != $3->ktip )
        {
            std::cerr << d_loc__.first_line << ": Az ertekadas jobb- es baloldalan kulonbozo tipusu kifejezesek allnak." << std::endl;
            exit(1);
        }
        else
        {
            $$ = new utasitas_leiro( d_loc__.first_line );
        }
        delete $3;
    }
;

be:
    BEMENET OLVAS AZONOSITO PONTOSVESSZO
    {
        if( szimb_tabla.count( *$3 ) == 0 )
        {
            std::cerr << d_loc__.first_line << ": A(z) '" << *$3 << "' valtozo nincs deklaralva." << std::endl;
            exit(1);
        }
        else
        {
            $$ = new utasitas_leiro( d_loc__.first_line );
        }
        delete $3;
    }
;

ki:
    KIMENET IR kifejezes PONTOSVESSZO
    {
        $$ = new utasitas_leiro( d_loc__.first_line );
        delete $3;
    }
;

elagazas:
    HA BALZAROJEL kifejezes JOBBZAROJEL KEZDES utasitasok VEGE
    {
        if( $3->ktip != Logikai )
        {
            std::cerr << d_loc__.first_line << ": Nem logikai tipusu az elagazas feltetele." << std::endl;
            exit(1);
        }
        else
        {
            $$ = new utasitas_leiro( $3->sor );
        }
        delete $3;
    }
|
    HA BALZAROJEL kifejezes JOBBZAROJEL KEZDES utasitasok VEGE KULONBEN KEZDES utasitasok VEGE
    {
        if( $3->ktip != Logikai )
        {
            std::cerr << d_loc__.first_line << ": Nem logikai tipusu az elagazas feltetele." << std::endl;
            exit(1);
        }
        else
        {
            $$ = new utasitas_leiro( $3->sor );
        }
        delete $3;
    }
;

ciklus:
    AMIG BALZAROJEL kifejezes JOBBZAROJEL KEZDES utasitasok VEGE
    {
        if( $3->ktip != Logikai )
        {
            std::cerr << d_loc__.first_line << ": Nem logikai tipusu a ciklus feltetele." << std::endl;
            exit(1);
        }
        else
        {
            $$ = new utasitas_leiro( $3->sor );
        }
        delete $3;
    }
;

kifejezes:
    FIXPONTOSSZAM
    {
        $$ = new kifejezes_leiro( d_loc__.first_line, Fixpontos );
        delete $1;
    }
|
    SZAM
    {
        $$ = new kifejezes_leiro( d_loc__.first_line, Egesz );
        delete $1;
    }
|
    IGAZ
    {
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
    }
|
    HAMIS
    {
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
    }
|
    AZONOSITO
    {
        if( szimb_tabla.count( *$1 ) == 0 )
        {
            std::cerr << d_loc__.first_line << ": A(z) '" << *$1 << "' valtozo nincs deklaralva." << std::endl;
            exit(1);
        }
        else
        {
            valtozo_leiro vl = szimb_tabla[*$1];
            $$ = new kifejezes_leiro( vl.def_sora, vl.vtip );
            delete $1;
        }
    }
|
    EGESZRESZ BALZAROJEL kifejezes JOBBZAROJEL
    {
        if( $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A 'fixpart' operator nem fixpontos tipusu kifejezesbol all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Egesz );
        delete $3;
    }
|
    TORTRESZ BALZAROJEL kifejezes JOBBZAROJEL
    {
        if( $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A 'fraction' operator nem fixpontos tipusu kifejezesbol all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Egesz );
        delete $3;
    }
|
    kifejezes PLUSZ kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A '+' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A '+' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A '+' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, $1->ktip );
        delete $1;
        delete $3;
    }
|
    kifejezes MINUSZ kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A '-' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A '-' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A '-' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, $1->ktip );
        delete $1;
        delete $3;
    }
|
    kifejezes SZORZAS kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A '*' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A '*' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A '*' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, $1->ktip );
        delete $1;
        delete $3;
    }
|
    kifejezes OSZTAS kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A 'div' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A 'div' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A 'div' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, $1->ktip );
        delete $1;
        delete $3;
    }
|
    kifejezes MARADEK kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A 'mod' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A 'mod' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A 'mod' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, $1->ktip );
        delete $1;
        delete $3;
    }
|
    kifejezes KISEBB kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A '<' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A '<' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A '<' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $1;
        delete $3;
    }
|
    kifejezes NAGYOBB kifejezes
    {
        if( $1->ktip != Egesz && $1->ktip != Fixpontos )
        {
            std::cerr << $1->sor << ": A '>' operator baloldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Egesz && $3->ktip != Fixpontos )
        {
            std::cerr << $3->sor << ": A '>' operator jobboldalan nem egesz vagy fixpontos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $3->sor << ": A '>' operator ket oldalan nem azonos tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $1;
        delete $3;
    }
|
    kifejezes EGYENLO kifejezes
    {
        if( $1->ktip != $3->ktip )
        {
            std::cerr << $1->sor << ": Az '=' operator jobb- es baloldalan kulonbozo tipusu kifejezesek allnak." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $1;
        delete $3;
    }
|
    kifejezes ES kifejezes
    {
        if( $1->ktip != Logikai )
        {
            std::cerr << $1->sor << ": Az 'and' operator baloldalan nem logikai tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Logikai )
        {
            std::cerr << $3->sor << ": Az 'and' operator jobboldalan nem logikai tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $1;
        delete $3;
    }
|
    kifejezes VAGY kifejezes
    {
        if( $1->ktip != Logikai )
        {
            std::cerr << $1->sor << ": Az 'or' operator baloldalan nem logikai tipusu kifejezes all." << std::endl;
            exit(1);
        }
        if( $3->ktip != Logikai )
        {
            std::cerr << $3->sor << ": Az 'or' operator jobboldalan nem logikai tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $1;
        delete $3;
    }
|
    NEM kifejezes
    {
        if( $2->ktip != Logikai )
        {
            std::cerr << $2->sor << ": A 'NEM' operator utan nem logikai tipusu kifejezes all." << std::endl;
            exit(1);
        }
        $$ = new kifejezes_leiro( d_loc__.first_line, Logikai );
        delete $2;
    }
|
    BALZAROJEL kifejezes JOBBZAROJEL
    {
        $$ = $2;
    }
;