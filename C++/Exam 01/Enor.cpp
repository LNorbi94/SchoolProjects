#include "stdafx.h"
#include "Enor.h"
#include <cstdlib>
#include <sstream>

using namespace std;

Enor::Enor(std::string filename)
{
	x.open(filename.c_str());
	if (!x.is_open())
	{
		cerr << "Nem letezik ilyen fajl." << endl;
		int alma;
		std::cin >> alma;
		exit(1);
	}
}


Enor::~Enor()
{
	x.close();
}

void Enor::First() { Read(); Next(); }

void Enor::Read()
{
	string temp;
	getline(x, temp);
	stringstream ss(temp);
	if (!x.fail())
	{
		sx = norm;
		ss >> dx.hal >> dx.id >> dx.kg;
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
		cur.hal = dx.hal;
		cur.kg = 0;

		for (; sx == norm && dx.hal == cur.hal; Read())
		{
			cur.kg += dx.kg;
		}
	}
}