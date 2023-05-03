namespace lab_work_7_func_module.utils;

internal static class Utils
{
    internal static int Factorial(this int n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }

    internal static double Invert(this double x)
    {
        return x * (-1);
    }
}