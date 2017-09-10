using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verem
{
    class Verem<T>
    {
        private int size;
		private int pos;
		private T[] stack;

		public Verem() : this(10) { }
		public Verem(int size)
		{
			this.size = size;
			pos = 0;
			stack = new T[size];
		}

		public bool Push(T value)
		{
			if (pos != size)
			{
				stack[pos] = value;
				pos++;
				return true;
			}
			return false;
		}

		public bool Pop()
		{
			T temp;
			return Pop(out temp);
		}

		public bool Pop(out T value)
		{
			if (pos != 0)
			{
				pos--;
				value = stack[pos];
				return true;
			}
			value = default(T);
			return false;
		}

		public void Clear()
		{
			pos = 0;
		}
    }
}
