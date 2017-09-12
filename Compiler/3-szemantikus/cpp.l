%option noyywrap c++ yylineno

%{
#include <iostream>
#include <stdlib.h>
#include "Parserbase.h"
%}

SZAMJEGY    [0-9]
WS          [ \t\n]
AZON_START  [a-zA-Z_]

%%

int         return Parser::INT;
main        return Parser::MAIN;
unsigned    return Parser::EGESZ; 
bool        return Parser::LOGIKAI;
fix     	return Parser::FIXPONTOS;
if          return Parser::HA;
else        return Parser::KULONBEN;
while       return Parser::AMIG;
cout        return Parser::KIMENET;
cin         return Parser::BEMENET;
intpart     return Parser::EGESZRESZ;
fraction    return Parser::TORTRESZ;
";"         return Parser::PONTOSVESSZO;
">>"        return Parser::OLVAS;
"<<"        return Parser::IR;
"="         return Parser::ERTEKADAS;
"=="        return Parser::EGYENLO;
"<"         return Parser::KISEBB;
">"         return Parser::NAGYOBB;
"+"         return Parser::PLUSZ;
"-"         return Parser::MINUSZ;
"*"         return Parser::SZORZAS;
"/"         return Parser::OSZTAS; 
"%"         return Parser::MARADEK;
&&          return Parser::ES;
"||"        return Parser::VAGY;
!           return Parser::NEM;
"{"         return Parser::KEZDES;
"}"         return Parser::VEGE;
"("         return Parser::BALZAROJEL;
")"         return Parser::JOBBZAROJEL;

{SZAMJEGY}+ return Parser::SZAM;
{SZAMJEGY}+"."{SZAMJEGY}{0,2} return Parser::FIXPONTOSSZAM;
true        return Parser::IGAZ;
false       return Parser::HAMIS;

"//".*\n    // nem kell semmit csinalni

{AZON_START}({AZON_START}|{SZAMJEGY})*    return Parser::AZONOSITO;

{WS}+   // feher szokozok: semmi teendo

. {
    std::cerr << lineno() << ". sor: Lexikalis hiba!" << std::endl;
    exit(1);
}

%%
