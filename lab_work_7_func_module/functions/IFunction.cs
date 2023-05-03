namespace lab_work_7_func_module.functions;

public abstract class Function
{
    public string ApproximateFunc;
    public string OriginalFunc;

    public virtual double FindApproximateFunc(double x, int n)
    {
        return 0.0;
    }
    public virtual double FindOriginalFunc(double x)
    {
        return 0.0;
    }
}