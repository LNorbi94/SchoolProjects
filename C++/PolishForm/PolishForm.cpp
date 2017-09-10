#include <string>
#include <queue>
#include <deque>
#include <iostream>
#include <fstream>

bool isCorrect(std::string input)
{
	auto stack = std::queue<char>();
	for (auto i = 0; i < input.size(); ++i)
	{
		if(input[i] == '(')
		{
			stack.push('(');
		}
		if (input[i] == ')')
		{
			if (stack.size() == 0)
				return false;
			stack.pop();
		}
		if (input[i] == '*' || input[i] == '/' || input[i] == '-' || input[i] == '+')
		{
			if (input[i - 1] == '*' || input[i - 1] == '/' || input[i - 1] == '-' || input[i - 1] == '+')
				return false;
		}
	}
	if (stack.size() > 0)
		return false;
	return true;
}

std::string toPolish(std::string input)
{
	if (!isCorrect(input))
		return "Input text format is not valid.";
	auto stack = std::deque<char>();
	std::string ret = "";
	for (auto& i : input)
	{
		if ( !(i == ' ') )
		{
			if (i == '(')
			{
				stack.push_back(i);
			}
			else if (i == ')')
			{
				while (stack.back() != '(')
				{
					ret += stack.back();
					ret += ", ";
					stack.pop_back();
				}
				stack.pop_back();
			}
			else if (i == '*' || i == '/')
			{
				stack.push_back(i);
			}
			else if (i == '+' || i == '-')
			{
				while ( !stack.empty() && (stack.back() == '*'
																		|| stack.back() == '/'
																	  || stack.back() == '+' || stack.back() == '-') )
				{
					ret += stack.back();
					ret += ", ";
					stack.pop_back();
				}
				stack.push_back(i);
			}
			else
			{
				ret += i;
				ret += ", ";
			}
		}
	}
	for(auto& i : stack)
	{
		ret += i;
		ret += ", ";
	}
	return ret.substr(0, ret.size() - 2);
}

size_t calculate(std::deque<char> input)
{
	while(!input.empty())
	{
		
	}
	return 0;
}

int main(int argc, char * argv[])
{
	std::ofstream f("output.txt");
	// ( 3 + 5 ) * 4 + ( 2 * 4)
	// ( 3 - 4 ) * 10 )
	// 3, 5, +, 4
	f << toPolish("a + b") << std::endl;
	f << toPolish("a * b + c") << std::endl;
	f << toPolish("a * (b + c)") << std::endl;
	f << toPolish("(u*v+10-a)*(b+1)^c+(k+2)/(15*f+20+g)") << std::endl;
	f << toPolish("((a+b-1)*c+5)+u/v*z^k^2+8") << std::endl;
	//std::cin >> b;
	//std::cout << toPolish("( 3 - 4 ) * 10 )");

	return 0;
}
