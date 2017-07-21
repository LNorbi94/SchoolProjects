#include <vector>
#include <stdint.h>

void insertSort(std::vector<int> &in)
{
	for (size_t i = 1; i < in.size(); ++i)
	{
		int temp = in[i];
		int j = i - 1;
		while (j > -1 && in[j] > temp)
		{
			in[j + 1] = in[j];
			--j;
		}
		in[j + 1] = temp;
	}
}
