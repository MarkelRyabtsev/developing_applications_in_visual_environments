namespace lab_work_12.model;

public class ResultData
{
    public double XValue { get; private set; }
    public double FuncValue { get; private set; }

    public ResultData(double xValue, double funcValue)
    {
        XValue = xValue;
        FuncValue = funcValue;
    }
}