namespace lab_work_3.utils;

public static class Utils
{
    public static int Factorial(this int n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }
    
    public static double Invert(this double x)
    {
        return x * (-1);
    }
}