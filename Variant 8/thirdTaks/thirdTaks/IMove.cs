using System;
namespace thirdTaks
{
	public interface IMove<T>
	{
        void Add(T data);
        T Remove();
        bool isEmpty();
    }
}

