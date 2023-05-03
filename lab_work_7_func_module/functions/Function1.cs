using System;
using lab_work_7_func_module.utils;

namespace lab_work_7_func_module.functions;

internal class Function1 : Function
{
    public string ApproximateFunc => "(-1)^n * (x^2n/(2n)!)";

    public string OriginalFunc => "cos(x)";

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
            return Math.Pow((-1), iteration) * (Math.Pow(x, 2 * iteration) / (2 * iteration).Factorial());
        }
    }

    public override double FindOriginalFunc(double x)
    {
        return Math.Cos(x);
    }
}