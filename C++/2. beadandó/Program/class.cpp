// Készítette:   Lestár Norbert
// Dátum:        2015.04.20.
// Neptun kód:   A8UZ7T
// E-mail:       lestar.norbert@gmail.com
// Csoport:      6. csoport
// Feladat:      3. beadandó/11. feladat
//               Bekezdéseket felsoroló objektum osztálya.

#include "class.h"

// Feladat:        Felsoroló létrehozása.
// Bemenõ adatok:  -
// Kimenõ adatok:  alapértelmezett felsoroló
// Tevékenység:	   Megnyitja a megadott szöveges állományt olvasásra, és inicializálja a sorszámozást.
Enor::Enor(const std::string &str)
{
	file.open(str.c_str());
	actual.id = 0;
}

// Feladat: 	   Szöveg következõ sorának olvasása.
// Bemenõ adatok:  alapértelmezett felsoroló
// Kimenõ adatok:  alapértelmezett felsoroló
// Tevékenység:	   Olvas egy újabb sort a szöveges állományból,
//                 ha nem sikerül az olvasás státuszát corrupted-re állítja, különben correct-re, majd
//                 a beolvasott sort istringstream objektumba helyezi.
void Enor::Read()
{
	std::string temp;
	std::getline(file, temp, '\n');
	if (!file.fail()) {
		stat = correct;
		line.clear();
		line.str(temp);
	}
	else {
		stat = corrupted;
	}
}

// Feladat: 	   A felsoroló Next() mûvelete.
// Bemenõ adatok:  alapértelmezett felsoroló
// Kimenõ adatok:  alapértelmezett felsoroló
// Tevékenység:	   Átlépi az üres sorokat, majd ha azok után nincs nem üres sor, akkor jelzi, hogy nincs több étel,
//                 különben beolvassa a következõ étel sorait, amelyekben
//                 egyrészt kiszámítja  a sorszámot
//                 másrészt kiszámolja a bevételt (összesített darab*egységár).
void Enor::Next()
{
    for(;stat==correct && line.str().size()==0; Read());
    over = stat == corrupted;
    if(!over){
        ++actual.id;
        actual.count = 0;
        actual.income = 0;
        for(;stat==correct && line.str().size()!=0; Read()){
            std::string temp;
            line >> temp;
            actual.name = temp;
            unsigned int price;
            line >> price;
            line >> temp;
            unsigned int count;
            line >> count;
            actual.price = price;
            actual.count += count;
        }
        actual.income = actual.price * actual.count;
    }
}
