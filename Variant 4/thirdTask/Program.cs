using System.Linq.Expressions;

class ItemStack<T>{
    public T X;
    public ItemStack<T> Next;

    public ItemStack(T x){
        this.X = x;
        this.Next = null;
    }
}

class MyStack<T>{
    private ItemStack<T> myStack;
    public MyStack(){
         myStack = null;
    }
    public void Push(T x){
        ItemStack<T> newItem = new ItemStack<T>(x);
        newItem.Next = myStack;
        myStack = newItem;
        Console.WriteLine("добовляем элемент " + x + " -> " + this);
    }
    public T Pop(){
        if(isEmpty()){
            throw new Exception("ошибка: в стеке больше нет элементов");
        }
        T x = myStack.X;
        myStack = myStack.Next;
        Console.WriteLine("забираем элемент " + x + " <- " + this);
        return x;
    }
    public bool isEmpty(){
        return myStack == null;
    }
    public override string ToString() {
        if(isEmpty()){
            return "стек пуст";
        }
        string result = "";
        ItemStack<T> stack = myStack;
        while(stack != null){
            result += stack.X + " ";
            stack = stack.Next;
        }
        char[] new_result = result.ToCharArray();
        Array.Reverse(new_result);
        return "{"+ new string(new_result) + " }";
    }
}

class ItemQueue<T>{
    public T X;
    public ItemQueue<T> Next;

    public ItemQueue(T x){
        this.X = x;
        this.Next = null;
    }
}
/*простая очередь*/
class MyQueue<T>{
    private ItemQueue<T> Head;
    private ItemQueue<T> Tail;
    
    public void Push(T x){
        ItemQueue<T> newItem = new ItemQueue<T>(x);
        if(isEmpty()){
            Head = Tail = newItem;
        } else {
            Tail.Next = newItem;
            Tail = newItem;
        }
        //Console.WriteLine(" PUSH  добовляем в очередь элемент "+ x + " -> " + this);
    }
    public T Pop(){
        if(isEmpty()){
            throw new Exception("ошибка: очередь пустая");
        }
        
        T x = Head.X;
        if (Head == Tail) {
            Head = Tail = null;
        } else {
            Head = Head.Next;
        }
        //Console.WriteLine(" POP   забираем из очереди элемент "+ x + " <- " + this);
        return x;

    }
    public bool isEmpty(){
        return Head == null;
    }

    public override string ToString() {
        string result = "";
        ItemQueue<T> queue = Head;
        while(queue != null){
            result += queue.X + " ";
            queue = queue.Next;
        }
        return "{ "+result + "}";
    }



}




class prog{
    static MyQueue<int[]> result = new MyQueue<int[]>();
    static void rec(int elem, MyStack<int> stack){
        if(stack.isEmpty()){
            return;
        }
        int x = stack.Pop();
        result.Push(new int[]{elem, x});
        rec(elem, stack);
        stack.Push(x);
    }
    static void Main(){
        MyStack<int> stack_1 = new MyStack<int>();
        MyStack<int> stack_2 = new MyStack<int>();

        Console.WriteLine();
        for(int i = 0; i < 3; i++){
            stack_1.Push(i);
        }
        for(int i = 2; i < 4; i++){
            stack_2.Push(i);
        }
        
        Console.WriteLine("делаем первый стек:");
        while(!stack_1.isEmpty()){
            int elem = stack_1.Pop();
            rec(elem, stack_2);
        }
        Console.WriteLine("\nделаем второй стек:");
        


        Console.Write("\nскалярное произведине двух stack:\n{");
        while(!result.isEmpty()){
            int[] elem = result.Pop();
            Console.Write("("+elem[0] +", "+elem[1]+") ");
        }
        Console.Write("}\n");
    }
}
