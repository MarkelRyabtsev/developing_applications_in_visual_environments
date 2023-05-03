using System;
using lab_work_7_func_module.utils;

namespace lab_work_7_func_module.functions;

internal class Function3 : Function
{
    public string ApproximateFunc => "x^(2n + 1) / (2n + 1)!";

    public string OriginalFunc => "(e^x - e^(-x)) / 2";

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
            return Math.Pow(x, 2 * iteration + 1) / (2 * iteration + 1).Factorial();
        }
    }

    public override double FindOriginalFunc(double x)
    {
        return (Math.Pow(Math.E, x) - Math.Pow(Math.E, x.Invert())) / 2;
    }
}