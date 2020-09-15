using System;

namespace 链表添加
{
    class Program
    { public class Node<T>
        { 
        public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t)
            { Next = null;
                Data = t;
            }
        }

        public class GenericList<T>
        {
            public T[] array=new T[4];
            public void Add(T item)
            {
                Node<T> q = new Node<T>(item);
                Node<T> p;
                if (head == null)
                {
                    head = q;
                    return;
                }
                p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = q;
            }


            public T getItem(int index)
            {
                return array[index];
            }

            public void setItem(int index, T value)
            {
                array[index] = value;
            }


            public Node<T> head;
           
            private Node<T> tail;
            public Node<T> Head
            {
                get => head;

            }


            public void Foreach(Action<T> action,T[] array)
            {

                {
                    Node<T> n = head;
                    while (n != null)
                    {
                        action(n.Data);
                            n = n.Next;
                    }
                    



                }
            }
        }


        
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            
           
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
       
            
            Action<int> action1 = delegate (int item)
             { Console.WriteLine(item); };
            list.Foreach(action1,list.array);
            int c = 0;
           
            Action<int> action2 = (m => c=Math.Max(m,c));
           
           
            list.Foreach(action2,list.array);
           
            
            Console.WriteLine("最大值为{0}", c);
            Action<int> action3 = (m =>c= Math.Min(m,c));
            list.Foreach(action3, list.array);

            Console.WriteLine("最小值为{0}",c);
            int sum = 0;
            Action<int> action4 =( m => sum += m);
            
            list.Foreach(action4, list.array);

            Console.WriteLine($"sum={sum}");


        }
    }
}
