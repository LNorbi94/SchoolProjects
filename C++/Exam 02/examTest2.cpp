// examTest2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Enor.h"
#include <iostream>


int main()
{
	Enor t("be.txt");
	int osszeg = 0;
	bool l = false;
	Struktura min;

	for (t.First(); !t.End(); t.Next())
	{
		Struktura e = t.Current();
		std::cout << e.azonosito.c_str() << e.db << "\n";
		osszeg += e.osszeg;
		if (e.db >= 3 && l) {
			if (min.osszeg > e.osszeg)
			   min = e;
		}
		else if (e.db >= 3 && !l) {
			min = e;
			l = true;
		}
	}
	std::cout << "Befolyt osszeg: " << osszeg << "\n";
	std::cout << "harmasok kozul min:" << min.azonosito.c_str() << "\n";
	int alma;
	std::cin >> alma;
	return 0;
}

