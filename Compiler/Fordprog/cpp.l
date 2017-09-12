%option noyywrap c++ yylineno

%{
#include <iostream>
#include <cstdlib>
#include "Parserbase.h"
%}

WS      [ \t\n]

%%

{WS}+         // whitespace - not needed

"//".*\n      // comment

"{"                     return Parser::LBRACE;
"}"                     return Parser::RBRACE;

"int"                   return Parser::INT;
"main"                  return Parser::MAIN;
"unsigned"              return Parser::UNSIGNED;
"bool"                  return Parser::BOOL;
"true"                  return Parser::TRUE;
"false"                 return Parser::FALSE;
"if"                    return Parser::IF;
"else"                  return Parser::ELSE;
"while"                 return Parser::WHILE;
"cout"                  return Parser::COUT;
"cin"                   return Parser::CIN;

[a-zA-Z_][a-zA-Z0-9_]*  return Parser::VARIABLE;

"("                     return Parser::OPEN;
")"                     return Parser::CLOSE;
"!"                     return Parser::NOT;
"&&"                    return Parser::AND;
"||"                    return Parser::OR;
"=="                    return Parser::EQUAL;
"<"                     return Parser::SMALLER;
">"                     return Parser::BIGGER;
"+"                     return Parser::PLUS;
"-"                     return Parser::MINUS;
"*"                     return Parser::MULTIPLY;
"/"                     return Parser::DIV;
"%"                     return Parser::MOD;
"<<"                    return Parser::WRITE;
">>"                    return Parser::READ;
"="                     return Parser::ASSIGNMENT;
";"                     return Parser::SEMICOLON;

[0-9]+                  return Parser::NUMBER;

.           {
                std::cerr << lineno() << ": Lexikalis hiba." << std::endl;
                exit(1);
            }

%%