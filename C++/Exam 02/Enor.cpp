#include "stdafx.h"
#include "Enor.h"

#include <iostream>
#include <cstdlib>
#include <sstream>

using namespace std;


Enor::Enor(string filename)
{
	x.open(filename.c_str());
	if (!x.is_open())
	{
		cerr << "Nem nyithato meg ez a fajl." << endl;
		int alma;
		std::cin >> alma;
		exit(1);
	}
}


Enor::~Enor()
{
	x.close();
}

void Enor::Read()
{
	string temp;
	getline(x, temp);
	if (temp.empty() && dx.azonosito == "") {
		cerr << "Ures a fajl." << endl;
		int alma;
		std::cin >> alma;
		exit(1);

	}
	if (!x.fail())
	{
		stringstream ss(temp);
		ss >> dx.azonosito >> dx.datum >> dx.osszeg;
		sx = norm;
	}
	else {
		sx = abnorm;
	}
}

void Enor::Next()
{
	vege = sx == abnorm;
	if (!End())
	{
		cur.azonosito = dx.azonosito;
		cur.osszeg = 0;
		cur.db = 0;

		for (; sx == norm && cur.azonosito == dx.azonosito; Read())
		{
			cur.osszeg += dx.osszeg;
			++cur.db;
		}
	}
}