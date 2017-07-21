// Készítette: Lestár Norbert
// Dátum:      2015.03.22.
// Feladat:    a legelsõ kétszer áthaladó utast meghatározó függvények

#include <vector>
#include <string>

#include "search.h"

using namespace std;

typedef std::vector<std::string>::size_type vector_size;

// Feladat:      Kiválasztja a stringekből álló tömbből az első feltételnek megfelelő elemet
// Tevékenység:  Lineáris kereséssel megkeresi a legelső feltételnek eleget tevõ elemet a megadott tömbben (vectorban), vagy nullát ad vissza ha nem volt egy se
// Bemenõ adat:  vector<string> t   - az utasok útlevélszámából álló vector
//               int j              - a vizsgált intervallum vége
// Kimenõ adat:  bool volt          - visszaadja, hogy talált-e a tömbben a megadott feltételnek tevő elemet, vagy sem

bool search(const vector<string> t, const int j)
{
    bool l = false;
    for(vector_size i=0; !l && i<j; ++i)
    {
        l = t[i] == t[j];
    }
    return l;
}

// Feladat:      Kiválasztja a stringekből álló tömbből az első feltételnek megfelelő elemet és visszaadja annak az indexét
// Tevékenység:  Lineáris kereséssel megkeresi a legelső feltételnek eleget tevõ elemet a megadott tömbben (vectorban), vagy nullát ad vissza ha nem volt egy se
// Bemenõ adat:  vector<string> t   - az utasok útlevélszámából álló vector
// Kimenõ adat:  int ind            - a feltételnek eleget tevő útlevélszámú utas indexe

int searchfirst(const vector<string> t)
{
    int ind = 0;
    bool l = false;
    for(vector_size i = 1; !l && i<t.size(); ++i)
    {
        l = search(t, i);
        ind = i;
    }
    if (!l)
        return 0;
    return ind;
}
