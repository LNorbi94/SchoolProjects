// Készítette: Lestár Norbert
// Dátum:      2015.03.22.
// Feladat:    segédfüggvények stringek fájlból való feltöltéséhez

#include <fstream>
#include <iostream>

#include "read.h"

using namespace std;

typedef std::vector<std::string>::size_type vector_size;

// Feladat:      Stringekből álló tömb(vector) feltöltése szöveges állományból
// Tevékenység:  Megnyitja a felhasználó által megadott szöveges állományt (sikertelen megnyitás
//               esetén hibát jelez, és kilép), majd a fájlból egymás után beolvassa az összes új sorban
//               lévõ számot és elhelyezi õket a vectorban.
// Bemenõ adat:  const string flnam    - szöveges állomány neve
// Kimenõ adat:  vector<string> t      - az útlevélszámokból álló vector
//               bool siker            - visszatérési érték, megadja hogy sikeres volt-e a fájl megnyitása

bool readfile(const string flnam, vector<string> &t)
{
    ifstream in;
    in.open(flnam.c_str());
    if(in.fail())
        return true;
    string out;
    while(!in.eof())
    {
        in >> out;
        if (out.size() <= 10 && out.size() >= 8)
            t.push_back(out);
    }
    if(t.size() > 0) {
        cout << "A hataron atkelo utasok: \n";
        for(vector_size i=0; i<t.size(); ++i){
            if (i<t.size()-1)
                cout << i+1 << ". utas: " << t[i] << ", ";
            else
                cout << i+1 << ". utas: " << t[i] << ". \n";
        }
    }
    return false;
}
