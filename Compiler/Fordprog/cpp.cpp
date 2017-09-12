#include <iostream>
#include <fstream>
#include "Parser.h"
#include <FlexLexer.h>

void input_handler (std::ifstream& in, int argc, char** argv)
{
    if (argc < 2)
    {
        std::cerr << "A forditando fajl nevet parancssori parameterben kell megadni." << std::endl;
        exit(1);
    }
    in.open (argv[1]);
    if (!in)
    {
        std::cerr << "A " << argv[1] << "fajlt nem sikerult megnyitni." << std::endl;
        exit(1);
    }
}

int main (int argc, char** argv)
{
    std::ifstream f;
    input_handler (f, argc, argv);
    Parser pars (f);
    pars.parse();
    return 0;
}