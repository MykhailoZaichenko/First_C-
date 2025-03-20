//int Add(int x, int y)
//{
//    return x + y;
//}
int a = 2, b = 3, res;
Console.WriteLine($"a = {a}, b = {b}");
res = Add(a, b);
Console.WriteLine($"a = {a}, b = {b}, res =  {res}");

partial class Program { 
    static int Add(int x, int y)
    {
        return x + y;
    }
}