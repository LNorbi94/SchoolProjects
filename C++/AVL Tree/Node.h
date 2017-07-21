#ifndef NODE_H
#define NODE_H

#include <iostream>
#include <memory>

template <typename T> 
class Node {
public:
	Node() : value(0), balance(0) { }
	explicit Node(T value) : value(value), balance(0) { }

public:
	Node& set(T newValue)                        { value = newValue; return *this; }
	T& getValue()                                { return value; }
	short getBalance() const                     { return balance; }
	short& setBalance(short rbalance)            { balance = rbalance; return balance; }
	std::shared_ptr< Node<T> >& getLeftBranch()  { return leftBranch; }
	std::shared_ptr< Node<T> >& getRightBranch() { return rightBranch; }
	void preOrder(std::ostream& stream) const
	{
		stream << " (";
		if (leftBranch) leftBranch->preOrder(stream);
		stream << value;
		if (rightBranch) rightBranch->preOrder(stream);
		stream << ") ";
	}
	void out(std::ostream& stream, const T value) const
	{
		stream << "A " << value << "-s ertek torlese/beillesztese.." << std::endl;
		preOrder(stream);
		stream << std::endl;
	}

	bool search(const T val) const
	{
		if(val < value)
		{
			if (leftBranch) return leftBranch->search(val);
			return false;
		}
		if(val > value)
		{
			if (rightBranch) return rightBranch->search(val);
			return false;
		}
		return val == value;
	}

private:
	T value;
	short balance;
	std::shared_ptr< Node<T> > leftBranch;
	std::shared_ptr< Node<T> > rightBranch;
};

template<typename T>
void insertNode(std::shared_ptr< Node<T> >& t, T k, bool& d)
{
	if (!t)
	{
		t = std::make_shared< Node<T> >(Node<T>(k));
		d = true;
	}
	else
	{
		if (k < t->getValue())
		{
			insertNode(t->getLeftBranch(), k, d);
			if (d)
				leftBranchGrown(t, d);
		}
		else if (k > t->getValue())
		{
			insertNode(t->getRightBranch(), k, d);
			if (d)
				rightBranchGrown(t, d);
		}
		else
		{
			d = false;
		}
	}
}

template<typename T>
void leftBranchGrown(std::shared_ptr< Node<T> >& t, bool& d)
{
	if (t->getBalance() == -1)
	{
		auto l = std::make_shared< Node<T> >( *t->getLeftBranch() );
		if (l->getBalance() == -1)
		{
			balanceMM(t, l);
		}
		else
		{
			balanceMP(t, l);
		}
		d = false;
	}
	else
	{
		t->setBalance(t->getBalance() - 1);
		d = t->getBalance() < 0;
	}
}

template<typename T>
void rightBranchGrown(std::shared_ptr< Node<T> >& t, bool& d)
{
	if (t->getBalance() == 1)
	{
		auto r = std::make_shared< Node<T> >( *t->getRightBranch() );
		if (r->getBalance() == 1)
		{
			balancePP(t, r);
		}
		else
		{
			balancePM(t, r);
		}
		d = false;
	}
	else
	{
		t->setBalance(t->getBalance() + 1);
		d = t->getBalance() > 0;
	}
}

template<typename T>
void balancePP(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > r)
{
	t->getRightBranch() = r->getLeftBranch();
	r->getLeftBranch() = t;
	r->setBalance(t->setBalance(0));
	t = r;
}

template<typename T>
void balanceMM(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > l)
{
	t->getLeftBranch() = l->getRightBranch();
	l->getRightBranch() = t;
	l->setBalance(t->setBalance(0));
	t = l;
}

template<typename T>
void balancePM(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > r)
{
	auto l = std::make_shared< Node<T> >( *r->getLeftBranch().get() );
	t->getRightBranch().reset();
	t->getRightBranch() = l->getLeftBranch();
	r->getLeftBranch() = l->getRightBranch();
	l->getLeftBranch() = t;
	l->getRightBranch() = r;
	t->setBalance(-(l->getBalance() + 1) / 2);
	r->setBalance((1 - l->getBalance()) / 2);
	l->setBalance(0);
	t = l;
}

template<typename T>
void balanceMP(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > l)
{
	auto r = std::make_shared< Node<T> >( *l->getRightBranch().get() );
	t->getLeftBranch().reset();
	l->getRightBranch() = r->getLeftBranch();
	r->getLeftBranch() = r->getRightBranch();
	r->getLeftBranch() = l;
	r->getRightBranch() = t;
	l->setBalance(-(r->getBalance() + 1) / 2);
	t->setBalance((1 - r->getBalance()) / 2);
	r->setBalance(0);
	t.swap(r);
}

template<typename T>
void deleteNode(std::shared_ptr< Node<T> >& t, const T k, bool& d)
{
	if(t)
	{
		if(k < t->getValue())
		{
			deleteNode(t->getLeftBranch(), k, d);
			if (d)
				leftBranchShrinked(t, d);
		}
		else if(k > t->getValue())
		{
			deleteNode(t->getRightBranch(), k, d);
			if (d)
				rightBranchShrinked(t, d);
		}
		else if(k == t->getValue())
		{
			deleteRoot(t, d);
		}
		else
		{
			d = false;
		}
	}
}

template<typename T>
void deleteRoot(std::shared_ptr< Node<T> >& t, bool& d)
{
	if(!t->getLeftBranch())
	{
		auto p = std::make_shared< Node<T> >( *t.get() );
		t = p->getRightBranch();
		d = true;
	}
	else if(!t->getRightBranch())
	{
		auto p = std::make_shared< Node<T> >(*t.get());
		t = p->getLeftBranch();
		d = true;
	}
	else
	{
		minOut(t->getRightBranch(), t->getValue(), d);
		if(d)
			rightBranchShrinked(t, d);
	}
}

template<typename T>
void minOut(std::shared_ptr< Node<T> >& t, T& min, bool& d)
{
	if(!t->getLeftBranch())
	{
		auto p = std::make_shared< Node<T> >( *t.get() );
		t = p->getRightBranch();
		min = p->getValue();
		p.reset();
		d = true;
	}
	else
	{
		minOut(t->getLeftBranch(), min, d);
		if(d)
			leftBranchShrinked(t, d);
	}
}

template<typename T>
void leftBranchShrinked(std::shared_ptr< Node<T> >& t, bool& d)
{
	if(t->getBalance() == 1)
	{
		balanceP(t, d);
	}
	else
	{
		t->setBalance(t->getBalance() + 1);
		d = t->getBalance() == 0;
	}
}

template<typename T>
void rightBranchShrinked(std::shared_ptr< Node<T> >& t, bool& d)
{
	if (t->getBalance() == -1)
	{
		balanceM(t, d);
	}
	else
	{
		t->setBalance(t->getBalance() - 1);
		d = t->getBalance() == 0;
	}
}

template<typename T>
void balanceP(std::shared_ptr< Node<T> >& t, bool& d)
{
	auto r = std::make_shared< Node<T> >(*t->getRightBranch().get());
	if(r->getBalance() == -1)
	{
		balancePM(t, r);
	}
	else if(r->getBalance() == 0)
	{
		balanceP0(t, r);
		d = false;
	}
	else if(r->getBalance() == 1)
	{
		balancePP(t, r);
	}
}

template<typename T>
void balanceM(std::shared_ptr< Node<T> >& t, bool& d)
{
	auto l = std::make_shared< Node<T> >(*t->getLeftBranch().get());
	if (l->getBalance() == -1)
	{
		balanceMP(t, l);
	}
	else if (l->getBalance() == 0)
	{
		balanceM0(t, l);
		d = false;
	}
	else if (l->getBalance() == 1)
	{
		balanceMM(t, l);
	}
}

template<typename T>
void balanceP0(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > r)
{
	t->getRightBranch() = r->getLeftBranch();
	r->getLeftBranch() = t;
	t->setBalance(1);
	r->setBalance(-1);
	t = r;
}

template<typename T>
void balanceM0(std::shared_ptr< Node<T> >& t, std::shared_ptr< Node<T> > l)
{
	t->getLeftBranch() = l->getRightBranch();
	l->getRightBranch() = t;
	t->setBalance(-1);
	l->setBalance(1);
	t = l;
}

#endif /* end of include guard: NODE_H */
