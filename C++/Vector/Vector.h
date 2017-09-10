#pragma once

#include <stddef.h>
#include <cassert>

template <typename T>
class Vector
{
public:
	typedef size_t size_type;

	class reverse_iterator
	{
	public:
		typedef reverse_iterator self_type;
		typedef T* pointer;
		typedef T value_type;
		typedef T& reference;

		reverse_iterator(pointer ptr) : ptr(ptr) {  }
		self_type operator++()
		{
			--ptr;
			return *this;
		}
		self_type operator++(int /* junk */)
		{
			self_type i = *this;
			--ptr;
			return i;
		}
		self_type operator--()
		{
			++ptr;
			return *this;
		}
		self_type operator--(int /* junk */)
		{
			self_type i = *this;
			++ptr;
			return i;
		}
		self_type& operator+(const int num)
		{
			ptr = ptr - num;
			return *this;
		}
		self_type& operator-(const int num)
		{
			ptr = ptr + num;
			return *this;
		}
		reference operator*() { return *ptr; }
		pointer operator->() { return ptr; }
		bool operator==(const self_type& rhs) { return ptr == rhs.ptr; }
		bool operator!=(const self_type& rhs) { return ptr != rhs.ptr; }
		bool operator<(const self_type& rhs)  { return ptr > rhs.ptr; }
	private:
		pointer ptr;
	};
	class iterator
	{
	public:
		typedef iterator self_type;
		typedef T* pointer;
		typedef T value_type;
		typedef T& reference;

		iterator(pointer ptr) : ptr(ptr) {  }
		self_type operator++()
		{
			++ptr;
			return *this;
		}
		self_type operator++(int /* junk */)
		{
			self_type i = *this;
			++ptr;
			return i;
		}
		self_type operator--()
		{
			--ptr;
			return *this;
		}
		self_type operator--(int /* junk */)
		{
			self_type i = *this;
			--ptr;
			return i;
		}
		self_type& operator+(const int num)
		{
			ptr = ptr + num;
			return *this;
		}
		self_type& operator-(const int num)
		{
			ptr = ptr - num;
			return *this;
		}
		reference operator*() { return *ptr; }
		pointer operator->() { return ptr; }
		bool operator==(const self_type& rhs) { return ptr == rhs.ptr; }
		bool operator!=(const self_type& rhs) { return ptr != rhs.ptr; }
		bool operator<(const self_type& rhs)  { return ptr < rhs.ptr; }
	private:
		pointer ptr;
	};

	Vector() : currentSize(0), maxSize(1) { array = new T[1]; }
	~Vector() { delete[] array; }
	explicit Vector(const size_type number) : currentSize(0), maxSize(number)
	{
		array = new T[number];
	}
	Vector& operator=(const Vector& rhs)
	{
		empty();
		reserve(rhs.capacity());
		currentSize = rhs.size();
		for (size_type i = 0; i < currentSize; ++i)
		{
			array[i] = rhs.array[i];
		}
		return *this;
	}
	void push_back(const T item)
	{
		resize();
		array[currentSize] = item;
		++currentSize;
	}
	T pop_back()
	{
		T temp = array[currentSize - 1];
		--currentSize;
		resize();
		return temp;
	}
	T& at(const size_type index) const
	{
		assert (index < currentSize);
		return array[index];
	}
	T& operator[](const size_type index) const
	{
		return at(index);
	}
	iterator begin()
	{
		return iterator(array);
	}
	iterator end()
	{
		return iterator(array + currentSize);
	}
	reverse_iterator rbegin()
	{
		return reverse_iterator(array + currentSize - 1);
	}
	reverse_iterator rend()
	{
		return reverse_iterator(array - 1);
	}
	size_type size() const
	{
		return currentSize;
	}
	size_type capacity() const
	{
		return maxSize;
	}
	void clear()
	{
		currentSize = 0;
		resize(1);
	}
	bool empty()
	{
		return currentSize == 0;
	}
	void reserve(size_type size)
	{
		array = new T[size];
		maxSize = size;
	}
	void resize(size_type size)
	{
		maxSize = size;
		T* temp = new T[maxSize];
		for (size_type i = 0; i < currentSize; ++i)
		{
			temp[i] = array[i];
		}
		delete[] array;
		array = temp;
	}
private:
	void resize()
	{
		if (currentSize + 1 > maxSize)
		{
			maxSize = maxSize * 2;
			T* temp = new T[maxSize];
			for (size_type i = 0; i < currentSize; ++i)
			{
				temp[i] = array[i];
			}
			delete[] array;
			array = temp;
		}
	}
	T* array;
	size_type currentSize;
	size_type maxSize;
};
