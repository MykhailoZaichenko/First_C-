using System.Net.Http.Metrics;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(10);
            }
            Console.WriteLine("Array: ");
            for (int i = 0;i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }



            int[,] matr = new int[2, 3];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = i + j;
                }
            }
            Console.WriteLine("Matr: ") ;
            for ( int i = 0; i < matr.GetLength (0); i++)
            {
                for (int j = 0;j < matr.GetLength (1); j++)
                {
                    Console.Write($"{matr[i, j]}");
                }
                Console.WriteLine() ;
            }
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                Console.Write("You pressed");
                Console.WriteLine(cki.Key);

            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
