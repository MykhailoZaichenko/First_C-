namespace First_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);
            Console.WriteLine("Hello, {0}!!!", name);
            Console.WriteLine($"Hello {name}");
        }
    }
}
