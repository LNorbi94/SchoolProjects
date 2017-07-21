// Készítette: Lestár Norbert
// Dátum:      2015.03.01.
// Neptun kód: A8UZ7T
// E-mail:     lestar.norbert@gmail.com
// Csoport:    6
// Feladat:    0. beadandó / 11. feladat:
//             A Föld felszínének egy vonala mentén egyenlő távolságonként megmértük a terep tengerszint feletti magasságát,
//             és a mért értékeket egy tömbben tároljuk. Keressük meg a legmagasabb völgyet a mérési sorozatban!

#include <iostream>
#include <vector>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;

typedef vector<int>::size_type vector_size;

// Feladat:      Egész számokból álló tömb(vector) feltöltése szöveges állományból
// Tevékenység:  Megnyitja a felhasználó által megadott szöveges állományt (sikertelen megnyitás
//               esetén hibát jelez, és kilép), majd a fájlból egymás után beolvassa az összes új sorban
//               lévő számot és elhelyezi őket a vectorban.
// Bemenő adat:  const string flnam    - szöveges állomány neve
// Kimenő adat:  vector<int> t         - a mérésekből álló vector
//               bool siker            - visszatérési érték, megadja hogy sikeres volt-e a fájl megnyitása

bool readfile(const string flnam, vector<int> &t)
{
    ifstream in;
    in.open(flnam.c_str());
    if(in.fail())
        return true;
    string out;
    while(!in.eof())
    {
        int i = 0;
        in >> out;
        stringstream ss(out);
        ss >> i;
        if (ss && i >= 0)
            t.push_back(i);
    }
    if(t.size() > 0) {
        cout << "A mert tengerszint feletti magassagok a kovetkezok voltak: \n";
        for(vector_size i=0; i<t.size(); ++i){
            if (i<t.size()-1)
                cout << i+1 << ". magassag: " << t[i] << " m, ";
            else
                cout << i+1 << ". magassag: " << t[i] << " m. \n";
        }
    }
    return false;
}

// Feladat:      Kiválasztja az egész számokat tartalmazó tömbből a legnagyobb völgyet
// Tevékenység:  Feltételes maximumkereséssel megkeresi a legnagyobb feltételnek eleget tevő számot a megadott tömbben (vectorban), vagy nullát ad vissza ha nem volt egy se
// Bemenő adat:  vector<int> t   - a mérésekből álló vector
// Kimenő adat:  int maxh        - a mért adatok közül a legmagasabban található pont (visszatérési érték)

int searchmax(const vector<int> t)
{
    if(t.size() < 3)
        return 0;
    bool l = false;
    int maxh;
    for(vector_size i=1; i<t.size()-1; ++i){
        if (!(t[i-1] > t[i] && t[i+1] > t[i]))
            continue;
        if (l) {
            if (maxh < t[i])
                maxh = t[i];
        } else {
            l = true;
            maxh = t[i];
        }
    }
    if (!l)
        return 0;
    return maxh;
}

int main()
{
    string exit;
    do {
    vector<int> heights;

    //Adatok beolvasás fájlból, és sikeres lefutás esetén azok kiírása.
    cout << "Kerem adja meg a fajl nevet, vagy lepjen ki a ':q' beirasaval! \n >> ";
    string filename;
    cin >> filename;
    if (filename == ":q")
        break;
    else if (readfile(filename, heights)) {
        cout << "Hiba tortent a fajl beolvasasakor! \n";
        continue;
    }

    //Feladat kiértékelése, majd kiírása, ha nem üres a vektor.
    if(searchmax(heights) != 0)
        cout << "Legmagasabb volgy: \n" << searchmax(heights) << " m. \n";
    else
        cout << "Nincs eleg rendelkezesre allo adat a legnagyobb volgy megallapitasara. \n";
    cout << "Ujra szeretne kezdeni? (i/n) \n >> ";
    cin >> exit;
    }while(exit[0] != 'n' && exit[0] != 'N');

    return 0;
}
