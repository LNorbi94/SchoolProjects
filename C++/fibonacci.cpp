int fRec(int n)
{
	if (n == 1 || n == 2) return 1;
	return fRec(n - 2) + fRec(n - 1);
}

int fib(int n)
{
	int fst = 0;
	int snd = 1;
	int fib = 0;
	if (n < 2)
		return 1;
	for (int i = 3; i < n; ++i)
	{
		fib = fst + snd;
		fst = snd;
		snd = fib;
	}
	return fib;
}

long long fibonacci(int n)
{
	auto a = 1;
	auto b = 0;
	auto p = 0;
	auto q = 1;
	while (n > 0)
	{
		if (n % 2 == 0)
		{
			auto oldp = p;
			p = p * p + q * q;
			q = 2 * oldp * q + q * q;
			n /= 2;
		}
		else
		{
			auto olda = a;
			a = q * (a + b) + a * p;
			b = b * p + olda * q;
			--n;
		}
	}
	return b;
}
