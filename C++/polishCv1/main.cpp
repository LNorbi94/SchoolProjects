#include "polishCalculator.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    PolishCalculator* w = new PolishCalculator;
    w->show();

    return a.exec();
}
