using System;
using lab_work_3.utils;

namespace lab_work_3.model;

public class Result
{
    public double X { get; private set; }
    public int N { get; private set; }
    
    public double ApproximateFunc { get; private set; }
    public double OriginalFunc { get; private set; }

    public Result(double x, int n)
    {
        this.X = x;
        this.N = n;
        this.ApproximateFunc = SolveApproximateFunc();
        this.OriginalFunc = SolveOriginalFunc();
    }

    private double SolveApproximateFunc()
    {
        var result = 0.0;
        for (var i = 0; i <= this.N; i++)
        {
            result += SolveFunction(i);
        }

        return result;

        double SolveFunction(int iteration)
        {
            return Math.Pow(this.X, 2 * iteration + 1) / (2 * iteration + 1).Factorial();
        }
    }
    
    private double SolveOriginalFunc()
    {
        return (Math.Pow(Math.E, this.X) - Math.Pow(Math.E, this.X.Invert())) / 2;
    }
}