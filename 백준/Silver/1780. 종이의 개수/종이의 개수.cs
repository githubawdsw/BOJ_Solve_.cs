using System;
using System.Collections.Generic;
using System.Text;
namespace BFS_DFS_Reculsive
{
    
    class PaperNumbuer_1780
    {
        static int N;
        static int[,] board = new int[3000, 3000];
        static int[] count = new int[3];
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            for (int i =0; i<N; i++)
            {
                string[] rowcol = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = int.Parse(rowcol[j]);
                }
            }

            Reculsive(0, 0, N);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(count[i]);
            }
        }

        public static void Reculsive(int x , int y , int _n)
        {
            if (check(x,y,_n))
            {
                count[board[x, y] + 1] += 1;
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Reculsive(x + i * (_n / 3), y + j * (_n / 3), _n / 3);
                }
            }

        }

        public static bool check(int x, int y ,int _n)
        {
            for (int i = x; i < x + _n; i++)
            {
                for (int j = y; j < y + _n; j++)
                {
                    if (board[i, j] != board[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
