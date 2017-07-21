// Készítette: Lestár Norbert
// Dátum:      2015.03.22.
// Neptun kód: A8UZ7T
// E-mail:     lestar.norbert@gmail.com
// Csoport:    6
// Feladat:    1. beadandó / 11. feladat:
//             Egy határállomáson feljegyezték az átlépõ utasok útlevélszámát. Melyik útlevélszámú utas
//             fordult meg leghamarabb másodszor a határon?

#include <iostream>
#include <vector>
#include <fstream>
#include <string>

#include "read.h"
#include "search.h"

using namespace std;

int main()
{
    string exit;
    do {
    vector<string> border;

    //Adatok beolvasás fájlból, és sikeres lefutás esetén azok kiírása.
    cout << "Kerem adja meg a fajl nevet, vagy lepjen ki a ':q' beirasaval! \n >> ";
    string filename;
    cin >> filename;
    if (filename == ":q")
        break;
    else if (readfile(filename, border)) {
        cout << "Hiba tortent a fajl beolvasasakor! \n";
        continue;
    }

    //Feladat kiértékelése, majd kiírása, ha nem üres a vektor.
    const int ind = searchfirst(border);
    if(ind != 0)
        cout << "Ketszer kelt at elsokent: \n" << border[ind] << " utlevelszammal rendelkezo utas. \n";
    else
        cout << "Senki se kelt at ketszer, vagy nincs eleg rendelkezesre allo adat. \n";
    cout << "Ujra szeretne kezdeni? (i/n) \n >> ";
    cin >> exit;
    }while(exit[0] != 'n' && exit[0] != 'N');

    return 0;
}
