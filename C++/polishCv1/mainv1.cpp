#include <QtWidgets/QApplication>
#include "polishCalculator.h"

int main(int argc, char* argv[])
{
	QApplication app(argc, argv);

	PolishCalculator* calc = new PolishCalculator;
	calc->show();

	return app.exec();
}
