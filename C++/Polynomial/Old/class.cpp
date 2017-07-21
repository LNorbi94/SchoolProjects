/*
* File:   class.cpp
* Author: Lestár Norbert
*
* Created on April 17, 2015, 9:10 PM
*/

#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <cmath>

typedef std::vector<std::string>::const_reverse_iterator str_r_iterator;

template <class T>
class Polynomial {
  public:
	Polynomial(std::vector<T> container);
	Polynomial(std::string input);
	~Polynomial();
	const size_t getDegree();
	const std::vector<T> getCoeff();
	const T getCoeff(const size_t index);
	T evaluateAt(T x);

	const std::string Polynomial<T>::show() {
		using namespace std;
		string ss = "";
		size_t j = coefficient.size();
		for (std::vector<T>::const_reverse_iterator i = coefficient.rbegin(); i != coefficient.rend(); ++i) {
			T temp = *i;
			ss += std::to_string(temp);
			ss += "x";
			ss += "^";
			ss += std::to_string(--j);
			if (j != 0)
				ss += " + ";
		}
		return ss;
	}

	inline Polynomial<T> operator+(Polynomial<T> other) {
		using namespace std;
		vector<T> temp_b = (degree >= other.getDegree() ? coefficient : other.getCoeff());
		vector<T> temp_s = (degree < other.getDegree() ? coefficient : other.getCoeff());
		vector<T> coresult;
		coresult.reserve(temp_b.size());

		for (size_t i = 0; i < temp_b.size(); ++i) {
			if (i >= temp_s.size())
				coresult.push_back(temp_b[i]);
			else
				coresult.push_back(coefficient[i] + other.getCoeff(i));

		}
		Polynomial<T> result(coresult);

		return result;
	}

	inline Polynomial<T> operator-(Polynomial<T> other) {
		using namespace std;
		vector <T> otherV(other.getCoeff());
		if (degree >= other.getDegree()) {
			otherV.resize(degree + 1);
		} else {
			coefficient.resize(other.getDegree() + 1);
		}
		vector<T> coresult;

		for (size_t i = 0; i < coefficient.size(); ++i) {
			coresult.push_back(coefficient[i] - otherV[i]);
		}
		Polynomial<T> result(coresult);

		return result;
	}

	inline Polynomial<T> operator*(Polynomial<T> other) {
		using namespace std;
		vector<T> temp_b = (degree >= other.getDegree() ? coefficient : other.getCoeff());
		vector<T> temp_s = (degree < other.getDegree() ? coefficient : other.getCoeff());
		vector<T> coresult;
		coresult.resize((degree + other.getDegree()) + 1);
		
		for (size_t i = 0; i < temp_b.size(); ++i) {
			for (size_t j = 0; j < temp_s.size(); ++j) {
				coresult[i + j] += (temp_b[i] * temp_s[j]);
			}
		}
		Polynomial<T> result(coresult);

		return result;
	}

	Polynomial<T> operator/(Polynomial<T> other) {
		using namespace std;
		size_t deg = other.getDegree();
		vector<T> result(deg + 1);
		reverse(coefficient.begin(), coefficient.end());
		vector<T> other_vec = other.getCoeff();
		reverse(other_vec.begin(), other_vec.end());
		vector<T> temp(deg + 1);


		for (size_t i = 0; i <= deg; ++i)
		{
			if (i == 0) {
				result[i] = coefficient[0] / other_vec[0];
				for (size_t j = 0; j < deg; ++j)
				{
					temp[j] = coefficient[j + 1] - (result[i] * other_vec[j + 1]);
				}
				temp[deg] = coefficient[deg];
			}
			else {
				result[i] = temp[0] / other_vec[0];
				for (size_t j = 0; j < deg; ++j)
				{
					temp[j] = temp[j + 1] - (result[i] * other_vec[j + 1]);
				}
				temp[deg] = coefficient[deg + i];
			}
		}

		reverse(result.begin(), result.end());
		Polynomial<T> result_p(result);
		reverse(coefficient.begin(), coefficient.end());

		return result_p;
	}

	Polynomial<T> operator %(Polynomial<T> other) {
		using namespace std;
		size_t deg = other.getDegree();
		vector<T> result(deg + 1);
		reverse(coefficient.begin(), coefficient.end());
		vector<T> other_vec = other.getCoeff();
		reverse(other_vec.begin(), other_vec.end());
		vector<T> temp(deg);


		for (size_t i = 0; i <= deg; ++i)
		{
			if (i == 0) {
				result[i] = coefficient[0] / other_vec[0];
				for (size_t j = 0; j < deg-1; ++j)
				{
					temp[j] = coefficient[j + 1] - (result[i] * other_vec[j + 1]);
				}
				 temp[deg-1] = coefficient[deg];
			}
			else {
				result[i] = temp[0] / other_vec[0];
				for (size_t j = 0; j < deg-1; ++j)
				{
					temp[j] = temp[j + 1] - (result[i] * other_vec[j + 1]);
				}
				temp[deg-1] = coefficient[deg + i];
			}
		}

		reverse(temp.begin(), temp.end());
		Polynomial<T> result_p(temp);
		reverse(coefficient.begin(), coefficient.end());

		return result_p;
	}
private:
	size_t degree;
	std::vector<T> coefficient;
};

template <class T>
Polynomial<T>::Polynomial(std::string input) {
	std::vector<std::string> seglist;
	std::stringstream ss(input);
	std::string segment;

	while (std::getline(ss, segment, '+')) {
		seglist.push_back(segment);
	}

	for (size_t i = 0; i < seglist.size(); ++i) {
		for (size_t j = 0; j < seglist[i].size(); j++) {
			if (seglist[i].at(j) == 'x' || seglist[i].at(j) == '^')
				seglist[i].at(j) = ' ';
		}
	}

	for (str_r_iterator i = seglist.rbegin(); i < seglist.rend(); ++i) {
		std::stringstream ss(*i);
		T temp;
		ss >> temp;
		coefficient.push_back(temp);
	}

	coefficient.shrink_to_fit();
	degree = coefficient.size() - 1;
}

template <class T>
Polynomial<T>::Polynomial(std::vector<T> container) {
	coefficient = container;
	degree = container.size();
}

template <class T>
Polynomial<T>::~Polynomial() {
	coefficient.clear();
	degree = 0;
}

template <class T>
T Polynomial<T>::evaluateAt(T x) {
	T sum = 0;

	for (size_t i = 0; i <= degree; ++i)
	{
		T temp = 1;

		for (size_t j = 0; j < i; ++j)
		{
			temp *= x;
		}

		sum += temp * coefficient[i];
	}

	return sum;
}

template <class T>
const size_t Polynomial<T>::getDegree() {
	return degree;
}

template <class T>
const std::vector<T> Polynomial<T>::getCoeff() {
	return coefficient;
}

template <class T>
const T Polynomial<T>::getCoeff(size_t index) {
	return coefficient[index];
}