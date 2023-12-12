namespace exam
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            MyStack<int> stack = new MyStack<int>();
            for(int i = 0; i < n; i++)
            {
                stack.Push(rnd.Next(0, 1000));
            }
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                visited.Add(rnd.Next(0, 1000));
            }
            while (stack.Count >= 0)
            {
                int item = stack.Pop();
                if(visited.Contains(item))
                    visited.Remove(item);
            }
            List<int> list = visited.ToList();
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class MyVal<T>
    {
        public T data;
        public MyVal<T> next;
        public MyVal(T value)
        {
            data = value;
            next = null;
        }
    }
    public class MyStack<T>
    {
        private MyVal<T> _top;
        private int _count;
        public MyStack()
        {
            _top = null;
            _count = 0;
        }
        public int Count
        {
            get => _count;
        }
        public void Push(T data)
        {
            MyVal<T> newnode = new MyVal<T>(data);
            if (_top == null)
            {
                _top = newnode;
                return;
            }
            newnode.next = _top;
            _top = newnode;
            _count++;
        }
        public void IsEmpty()
        {
            if (_top == null)
            {
                throw new Exception("Stack is empty");
            }
        }
        public T Peek()
        {
            IsEmpty();
            return _top.data;
        }
        public T Pop()
        {
            var item = Peek();
            _top = _top.next;
            _count--;
            return item;
        }
    }
}