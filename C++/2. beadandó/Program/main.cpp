// Készítette:   Lestár Norbert
// Dátum:        2015.04.20.
// Neptun kód:   A8UZ7T
// E-mail:       lestar.norbert@gmail.com
// Csoport:      6. csoport
// Feladat:      3. beadandó/11. feladat
//               Kiírja melyik étel hozta az étteremnek a legtöbb bevételt (összesített darab*egységár).
#include "class.h"

// Ellenőrzi hogy üres-e vagy hibás a fájl.
bool is_textfile_empty( const std::string filename ) {
    using namespace std;
    string s;
    ifstream f( filename.c_str(), ios::binary );
    if (f.fail())
        return true;

    while (getline( f, s )) {
            if (s.find_first_not_of(
                " \t\n\v\f\r"
                "\0\xFE\xFF"
      ) != string::npos)
      return false;
    }

    return true;
}

// Kiírja a fájl tartalmát.
void write(const std::string fname) {
    using namespace std;
    ifstream f;
    f.open(fname.c_str());
    cout << "Rendelesek:" << endl;
    cout << "============================" << endl;
    while(!f.eof()) {
        string temp;
        getline(f, temp);
        if (temp != "")
            cout << temp << endl;
    }
    cout << endl;
}

// Feladat: 	  Kiírja melyik étel hozta az étteremnek a legtöbb bevételt (összesített darab*egységár).
// Bemenõ adatok: Szöveges állomány
// Kimenõ adatok: Standard output
// Tevékenység:	  A szöveges állomány ételeinek felsorolására épülõ összegzés (maximum kiválasztás).
//                A felsoroló megmutatja a legtöbb bevételt hozó ételt.
//                Ennek segítségével a megfogalmazott maximum kiválasztás elvégezhetõ.
int main() {
	using namespace std;
    string exit;
    do {
    cout << "Kerem adja meg a fajl nevet, vagy lepjen ki a ':q' beirasaval! \n >> ";
    string filename;
    cin >> filename;
    if (filename == ":q")
        break;
    else if (is_textfile_empty(filename)) {
        cout << "Hiba tortent a fajl beolvasasakor! \n";
        cout << "Lehetseges okok: Hibas, ures, vagy nem letezo fajl. \n";
        continue;
    }
    write(filename);
	Enor foods(filename);
    foods.First();
    Food e = foods.Current();
    Food mname = foods.Current();
    unsigned int max = e.income;
    foods.Next();
    for(; !foods.End(); foods.Next()) {
            e = foods.Current();
            if(max < e.income) {
                max = e.income;
                mname = foods.Current();
            }
        }
    cout << "Legtobb bevetelt hozta: " << endl;
    cout << "============================" << endl;
    cout << mname.name << ", meghozza ennyit: " << mname.income << " Ft. \n";
    cout << "Ujra szeretne kezdeni? (i/n) \n >> ";
    cin >> exit;
    }while(exit[0] != 'n' && exit[0] != 'N');
	return 0;
}
