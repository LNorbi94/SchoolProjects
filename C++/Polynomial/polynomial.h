/* 
 * File:   polynomial.h
 * Author: Lestár Norbert
 *
 * Created on April 17, 2015, 9:10 PM
 */

typedef std::vector<std::string>::const_reverse_iterator str_riterator;
typedef std::vector<double>::const_reverse_iterator double_riterator;
typedef std::vector<double> type;

#ifndef POLYNOMIAL_H
#define	POLYNOMIAL_H

class Polynomial {
  public:
    Polynomial(std::string input);
    Polynomial(std::vector<double> container);
    ~Polynomial();
    Polynomial operator+(Polynomial other);
    Polynomial operator-(Polynomial other);
    Polynomial operator*(Polynomial other);
    Polynomial operator/(Polynomial other);
    Polynomial operator%(Polynomial other);
    const size_t getDegree();
    const type getCoeff();
    const double getCoeff(const size_t index);
    double evaluateAt(double x);
  private:
    size_t degree;
    type coefficient;
};

Polynomial::Polynomial(std::string input) {
    std::vector<std::string> seglist;
    std::stringstream ss(input);
    std::string segment;
    
    while(std::getline(ss, segment, '+')) {
        seglist.push_back(segment);
    }
    
    for(size_t i = 0; i < seglist.size(); ++i) {
        for(size_t j = 0; j < seglist[i].size(); j++) {
            if(seglist[i].at(j) == 'x' || seglist[i].at(j) == '^')
                seglist[i].at(j) = ' ';
        }
    }
    
    for(str_riterator i = seglist.rbegin(); i < seglist.rend(); ++i) {
        std::stringstream ss(*i);
        double temp;
        ss >> temp;
        coefficient.push_back(temp);
    }
    
    coefficient.shrink_to_fit();
    degree = coefficient.size()-1; 
}

Polynomial::Polynomial(std::vector<double> container) {
    coefficient = container;
    degree = container.size()-1;
}

Polynomial::~Polynomial() {
    if(coefficient.size() > 0)
        type().swap(coefficient);
}

double Polynomial::evaluateAt(double x) {
    double sum = 0.0;
    
    for(size_t i = 0; i <= degree; ++i)
    {
            double temp = 1.0;
            
            for(size_t j = 0; j < i; ++j)
            {
                temp *= x;
            }
            
            sum += temp * coefficient[i];
    }
    
    return sum;
}
 
const size_t Polynomial::getDegree() {
    return degree;
}

const type Polynomial::getCoeff() {
    return coefficient;
}
 
const double Polynomial::getCoeff(size_t index) {
    return coefficient[index];
}

#endif	/* POLYNOMIAL_H */