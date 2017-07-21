#pragma once
#include <fstream>

struct Struktura
{
	std::string azonosito;
	std::string datum;
	int osszeg;
	int db;
};

class Enor
{
public:
	Enor(std::string filename);
	~Enor();
	bool End() const { return vege; }
	Struktura Current() const { return cur; }
	void First() { Read();  Next(); }
	void Next();

private:
	enum Status{
		abnorm,
		norm
	};
	void Read();

	Status sx;
	Struktura dx;
	std::ifstream x;
	Struktura cur;

	bool vege;

};

