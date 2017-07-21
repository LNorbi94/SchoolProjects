// examTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Enor.h"
#include <iostream>


int main()
{
	Enor t("be");
	for (t.First(); !t.End(); t.Next())
	{
		Struktura e = t.Current();
		std::cout << e.hal.c_str() << ", " << e.kg;
	}
	return 0;
}

