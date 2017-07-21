#pragma once

#include <iostream>
#include <fstream>

struct Struktura
{
	std::string hal;
	std::string id;
	int kg;
};

class Enor
{
public:
	Enor(std::string filename);
	~Enor();
	Struktura Current() const { return cur; }
	bool End() const { return vege; }
	void First();
	void Next();
private:
	enum Status{
		abnorm,
		norm
	};
	bool vege;
	Status sx;
	Struktura cur;
	Struktura dx;
	std::ifstream x;
	void Read();
};

