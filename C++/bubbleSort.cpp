#include <vector>

void bubbleSort (std::vector<int>& in)
{
	for (size_t i = in.size() - 1; i > 1; --i)
	{
		for (size_t j = 0; j < i; ++j)
		{
			if (in[j + 1] < in[j])
			{
				in[j]			^= in[j + 1];
				in[j + 1] ^= in[j];
				in[j]			^= in[j + 1];
			}
		}
	}
}
