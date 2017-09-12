#ifndef SEMANTICS_H
#define SEMANTICS_H

#include <iostream>
#include <map>
#include <string>
#include <sstream>

enum type { number, boolean };

struct var_data
{
    var_data() {}
    var_data(size_t dRow, type vType)
    : decl_row(dRow)
    , var_type(vType)
    {}

    size_t decl_row;
    type var_type;
};

#endif