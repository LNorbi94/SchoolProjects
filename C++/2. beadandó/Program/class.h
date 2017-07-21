// Készítette:   Lestár Norbert
// Dátum:        2015.04.20.
// Neptun kód:   A8UZ7T
// E-mail:       lestar.norbert@gmail.com
// Csoport:      6. csoport
// Feladat:      3. beadandó/11. feladat
//               Bekezdéseket felsoroló objektum osztálya.
#ifndef CLASS_H
#define CLASS_H

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <stdlib.h>

enum Status {
	correct, corrupted
};

struct Food {
	size_t id;
	std::string name;
	std::string time;
	unsigned int count;
	unsigned int price;
    unsigned int income;
};

// Bekezdés-felsoroló típusa
// Típusértékek:   felsoroló objektumok
// Reprezentáció:  szöveges állomány adatfolyam objektuma
//                 az éppen kiolvasott sor
//                 sor-olvasás állapota
//                 aktuális bekezdés adatai
//                 utolsó étel-e vagy sem
// Mûveletei:      felsoroló létrehozása
//                 felsoroló mûveletek
//                 a szöveg következõ sorának olvasása
class Enor{
private:
	std::ifstream file;
	std::stringstream line;
	Status stat;
	Food actual;
	bool over;
	void Read();

public:
	Enor(const std::string &str);
	void First() {
		Read();
		Next();
	}
	void Next();
	Food Current() const {
		return actual;
	}
	bool End() const {
		return over;
	}
};

#endif
