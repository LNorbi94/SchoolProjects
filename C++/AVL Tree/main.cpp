#include <iostream>
#include <memory>

#include "Node.h"

int main( int argc, char* argv[] )
{
	auto t = std::make_shared< Node<int> >( Node<int> (82) );
	auto d = false;

	// Órai példa, többféle forgatásra is van példa.
	insertNode(t, 100, d);
	t->out(std::cout, 100);
	insertNode(t, 160, d);
	t->out(std::cout, 160);
	insertNode(t, 83, d);
	t->out(std::cout, 83);
	insertNode(t, 125, d);
	t->out(std::cout, 125);
	insertNode(t, 155, d);
	t->out(std::cout, 166);
	insertNode(t, 58, d);
	t->out(std::cout, 58);
	insertNode(t, 122, d);
	t->out(std::cout, 122);
	insertNode(t, 185, d);
	t->out(std::cout, 185);
	insertNode(t, 188, d);
	t->out(std::cout, 188);
	insertNode(t, 158, d);
	t->out(std::cout, 158);

	// Duplikáció ellenõrzése
	insertNode(t, 100, d);
	t->out(std::cout, 100);

	//Keresés
	std::cout << "188 megtalalhato-e a faban? ";
	if (t->search(188))
		std::cout << "Igen.";
	else
		std::cout << "Nem.";
	std::cout << std::endl;

	std::cout << "126 megtalalhato-e a faban? ";
	if (t->search(126))
		std::cout << "Igen.";
	else
		std::cout << "Nem.";
	std::cout << std::endl;

	// Fa Törlése
	deleteNode(t, 83, d);
	t->out(std::cout, 83);
	deleteNode(t, 82, d);
	t->out(std::cout, 82);
	deleteNode(t, 58, d);
	t->out(std::cout, 58);
	deleteNode(t, 100, d);
	t->out(std::cout, 100);
	deleteNode(t, 160, d);
	t->out(std::cout, 160);
	deleteNode(t, 155, d);
	t->out(std::cout, 155);
	deleteNode(t, 125, d);
	t->out(std::cout, 125);
	deleteNode(t, 122, d);
	t->out(std::cout, 122);
	deleteNode(t, 185, d);
	t->out(std::cout, 185);
	deleteNode(t, 188, d);
	t->out(std::cout, 158);

	// Duplikáció ellenõrzése
	deleteNode(t, 0, d);
	t->out(std::cout, 158);
	std::cin >> argc;
	return 0;
}
