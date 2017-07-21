#include <queue>

int different(std::queue<int>& deck)
{
	int diffNum = 0;
	int temp = deck.front();
	deck.pop();
	int tempB = 0;
	int tempC = -1;
	if (temp != deck.front())
		++diffNum;
	while(deck.size() != 0)
	{
		tempB = deck.front();
		deck.pop();
		if(temp == tempB)
		{
			if (tempC == -1)
				tempC = tempB;
		}
		else
		{
			temp = tempB;
			if (temp != tempC && (deck.size() == 0 || temp != deck.front()) )
				++diffNum;
			tempC = -1;
		}
	}
	return diffNum;
}
