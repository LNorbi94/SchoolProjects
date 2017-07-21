/* 
 * File:   main.cpp
 * Author: Lestár Norbert
 *
 * Created on April 17, 2015, 7:10 PM
 */

#include "operators.h"

int main(int argc, char* argv[]) {
    using namespace std;
    
    if(argc != 3 && argc != 5) {
        cout << "error: invalid number of arguments" << endl;
        cout << endl;
        cout << "Usage: ./name 'first polynom' 'second polynom' [name] [constant number]" << endl;
        cout << "Example for polynom: 5x^4 + 0x^3 + 0x^2 + 2x^1 + -3x^0." << endl;
        cout << "Third argument should be either f or g. (First or second polynom)" << endl;
        cout << "Last argument is the constant for evaluating the polynom." << endl;
        return 0;
    }
    string first = argv[1];
    string second = argv[2];
    double constant = atof(argv[4]);
    Polynomial f (first);
    Polynomial g (second);
    
    cout << "The polynoms you entered: \n";
    cout << "f(x) = " << first << "\n";
    cout << "g(x) = " << second << endl;
    cout << endl;
    cout << "f + g = " << show((f+g).getCoeff()) << endl;
    cout << "-----" << endl;
    cout << "f - g = " << show((f-g).getCoeff()) << endl;
    cout << "-----" << endl;
    cout << "f * g = " << show((f*g).getCoeff()) << endl;
    cout << "-----" << endl;
    if(*argv[3] == 'f') {
        cout << "f(" << constant << ") = " << f.evaluateAt(constant) << endl;
    } else if(*argv[3] == 'g') {
        cout << "g(" << constant << ") = " << g.evaluateAt(constant) << endl;
    }
    if (f.getDegree() > g.getDegree()) {
    cout << "-----" << endl;
    cout << "f / g = " << show((f/g).getCoeff()) << endl;
    cout << "-----" << endl;
    cout << "f % g = " << show((f%g).getCoeff()) << endl;
    cout << "-----" << endl;
    cout << show(f.getCoeff()) << " = \n" << show((((f/g)*g) + (f%g)).getCoeff()) << endl;
    }
    return 0;
}