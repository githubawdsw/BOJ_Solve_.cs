using System;
using System.Text;

namespace PriorityQueue_
{

    class BOJ_13975
    {
        public class Priority_Queue // 최소힙
        {
            static long[] heap = new long[1000005];
            int size = 0;
            public int SIZE
            {
                get { return size; }
                set { size = value; }
            }
            public void Add(long x)
            {
                heap[++size] = x;
                int idx = size;
                while (idx != 1)
                {
                    int par = idx / 2;
                    if (heap[idx] >= heap[par])
                        break;
                    long swap = heap[par];
                    heap[par] = heap[idx];
                    heap[idx] = swap;
                    idx = par;
                }
            }
            public long Top()
            {
                return heap[1];
            }
            public void Pop()
            {
                heap[1] = heap[size--];
                heap[size + 1] = 0;
                int idx = 1;
                while (idx * 2 <= size)
                {
                    int left = idx * 2; int right = idx * 2 + 1;
                    int bigger = left;
                    if (right <= size && heap[left] > heap[right])
                        bigger = right;
                    if (heap[idx] <= heap[bigger])
                        break;
                    long swap = heap[bigger];
                    heap[bigger] = heap[idx];
                    heap[idx] = swap;
                    idx = bigger;
                }
            }
        }
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int t = int.Parse(Console.ReadLine());
            while (t> 0)
            {
                t--;
                Priority_Queue pq = new Priority_Queue();
                int k = int.Parse(Console.ReadLine());
                string[] inputVal = Console.ReadLine().Split(' ');
                for (int i = 0; i < k; i++)
                    pq.Add(int.Parse(inputVal[i]));
                long sum = 0;
                while (pq.SIZE != 1)
                {
                    long x = pq.Top();
                    pq.Pop();
                    long y = pq.Top();
                    pq.Pop();
                    sum += x + y;
                    pq.Add(x + y);
                }
                sb.AppendLine(sum.ToString());
            }
            Console.WriteLine(sb);
        }
    }
    
}
