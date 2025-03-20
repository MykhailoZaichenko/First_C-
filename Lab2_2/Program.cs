namespace Lab2_2
{
    internal class Program
    {
        static int Add(int x, int y)
        {
            x += 10;
            return x + y;
        }
        static int AddByRef(ref int x, int y)
        {
            x += 10;
            return x + y;
        }
        static void addUsingOut(int x, int y, out int result)
        {
            result = x + y;
            x += 10;
        }
        static void Main(string[] args)
        {
            int a = 2, b = 3, res;
            //Console.WriteLine($"a = {a}, b = {b}");
            //res = Add(a, b);
            //Console.WriteLine($"{a} + {b} = {res}");
            //res = AddByRef(ref a, b);
            //Console.WriteLine($"{a} + {b} = {res}");
            addUsingOut(a, b, out res);
            Console.WriteLine($"a = {a}, b = {b}, res = {res}");
        }
    }
}
