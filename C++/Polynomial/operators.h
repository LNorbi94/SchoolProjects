/* 
 * File:   operators.h
 * Author: Lestár Norbert
 *
 * Created on April 17, 2015, 9:12 PM
 */

#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <cmath>

#include "polynomial.h"

using namespace std;

typedef std::vector<string>::const_reverse_iterator str_riterator;
typedef std::vector<double>::const_reverse_iterator double_riterator;


#ifndef OPERATORS_H
#define	OPERATORS_H

const string show(vector<double> coefficient) {
    string ss = "";
    size_t j = coefficient.size();
    for(double_riterator i = coefficient.rbegin(); i != coefficient.rend(); ++i)
    {
        double temp = *i;
        ss += std::to_string(temp);
        ss += "x";
        ss += "^";
        ss += std::to_string(--j);
        if(j != 0)
            ss += " + ";
    }
    return ss;
}
 
Polynomial Polynomial::operator+(Polynomial other) {
    vector<double> temp_b = ( degree >= other.getDegree() ? coefficient : other.getCoeff() );
    vector<double> temp_s = ( degree < other.getDegree() ? coefficient : other.getCoeff() );
    vector<double> coresult;
    coresult.reserve(temp_b.size());
    for(size_t i = 0; i < temp_b.size(); ++i)
    {
        if (i >= temp_s.size())
            coresult.push_back(temp_b[i]);
        else
            coresult.push_back(coefficient[i]+other.getCoeff(i));
        
    }
	
    Polynomial result(coresult);
    return result;   
}

Polynomial Polynomial::operator-(Polynomial other) {
	vector <double> otherV(other.getCoeff());
	if (degree >= other.getDegree()) {
		otherV.resize(degree + 1);
	} else {
		coefficient.resize(other.getDegree() + 1);
	}
	vector<double> coresult;
	for (size_t i = 0; i < coefficient.size(); ++i) {
		coresult.push_back(coefficient[i] - otherV[i]);
	}
	
	Polynomial result(coresult);
        return result;
}

Polynomial Polynomial::operator*(Polynomial other) {
    vector<double> temp_b = ( degree >= other.getDegree() ? coefficient : other.getCoeff() );
    vector<double> temp_s = ( degree < other.getDegree() ? coefficient : other.getCoeff() );
    vector<double> coresult;
    {
        size_t temp = (degree + other.getDegree()) + 1;
        coresult.resize(temp);
    }
    for(size_t i = 0; i < temp_b.size(); ++i)
    {
        for(size_t j = 0; j < temp_s.size(); ++j)
        {
             coresult[i+j] += (temp_b[i] * temp_s[j]);
        }
    }
	
    Polynomial result(coresult);
    return result;
}

Polynomial Polynomial::operator/(Polynomial other) {
    size_t deg = other.getDegree();
    vector<double> result(deg+1);
    reverse(coefficient.begin(), coefficient.end());
    vector<double> other_vec = other.getCoeff();
    reverse(other_vec.begin(), other_vec.end());
    vector<double> temp(deg);
    
    
    for(size_t i = 0; i <= deg; ++i)
    {
        if (i == 0) {
            result[i] = coefficient[0] / other_vec[0];
            for(size_t j = 0; j < deg; ++j)
            {
                temp[j] = coefficient[j+1] - (result[i] * other_vec[j+1]);
            }
            temp[deg] = coefficient[deg+1];
        }
        else {
            result[i] = temp[0] / other_vec[0];
            for(size_t j = 0; j < deg; ++j)
            {
                temp[j] = temp[j+1] - (result[i] * other_vec[j+1]);
            }
            temp[deg] = coefficient[deg+1+i];
        }
    }
    
    reverse(result.begin(), result.end());
	
    Polynomial result_p(result);
    reverse(coefficient.begin(), coefficient.end());
    
    return result_p;
}

Polynomial Polynomial::operator %(Polynomial other) {
    size_t deg = other.getDegree();
    vector<double> result(deg+1);
    reverse(coefficient.begin(), coefficient.end());
    vector<double> other_vec = other.getCoeff();
    reverse(other_vec.begin(), other_vec.end());
    vector<double> temp(deg);
    
    
    for(size_t i = 0; i <= deg; ++i)
    {
        if (i == 0) {
            result[i] = coefficient[0] / other_vec[0];
            for(size_t j = 0; j < deg; ++j)
            {
                temp[j] = coefficient[j+1] - (result[i] * other_vec[j+1]);
            }
            temp[deg] = coefficient[deg+1];
        }
        else {
            result[i] = temp[0] / other_vec[0];
            for(size_t j = 0; j < deg; ++j)
            {
                temp[j] = temp[j+1] - (result[i] * other_vec[j+1]);
            }
            temp[deg] = coefficient[deg+1+i];
        }
    }
    
    reverse(temp.begin(), temp.end());
    Polynomial result_p(temp);
    reverse(coefficient.begin(), coefficient.end());
    
    return result_p;
}

#endif	/* OPERATORS_H */