#ifndef SEMANTICS_H
#define SEMANTICS_H

#include <string>
#include <iostream>
#include <cstdlib>
#include <map>
#include <sstream>

enum type { natural, boolean };

struct var_data
{
    int decl_row;
    type var_type;
    var_data() {}
    var_data( int row, type t )
        : decl_row(row), var_type(t) {}
};

#endif //SEMANTICS_H
