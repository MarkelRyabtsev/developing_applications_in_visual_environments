using System;
using lab_work_7_func_module.utils;

namespace lab_work_7_func_module.functions;

internal class Function2 : Function
{
    public string ApproximateFunc => "(2n + 1) / n!) * 2^(2n)";

    public string OriginalFunc => "(1 + 2x^2) * e^(x^2)";

    public override double FindApproximateFunc(double x, int n)
    {
        var result = 0.0;
        for (var i = 0; i <= n; i++)
        {
            result += SolveFunction(i);
        }

        return result;

        double SolveFunction(int iteration)
        {
            return ((2 * iteration + 1) / iteration.Factorial()) * Math.Pow(x, 2 * iteration);
        }
    }

    public override double FindOriginalFunc(double x)
    {
        return (1 + 2 * Math.Pow(x, 2)) * Math.Pow(Math.E, Math.Pow(x, 2));
    }
}