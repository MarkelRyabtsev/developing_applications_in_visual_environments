using System;
using lab_work_7_func_module.functions;

namespace lab_work_7.model;

public class Result
{
    public double X { get; private set; }
    public int N { get; private set; }
    
    public double ApproximateFunc { get; private set; }
    public double OriginalFunc { get; private set; }
    
    public string ApproximateFuncName { get; private set; }
    public string OriginalFuncName { get; private set; }

    public Result(double x, int n, Function func)
    {
        this.X = x;
        this.N = n;
        this.ApproximateFunc = func.FindApproximateFunc(x, n);
        this.OriginalFunc = func.FindOriginalFunc(x);
        this.ApproximateFuncName = func.ApproximateFunc;
        this.OriginalFuncName = func.OriginalFunc;
    }
}