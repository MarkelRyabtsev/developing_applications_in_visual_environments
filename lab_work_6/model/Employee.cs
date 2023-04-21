using System.Text.Json.Serialization;

namespace lab_work_6.model;

public class Employee
{
    private const int LIMIT_HOURS = 144;
    private const int INCOME_TAX_PERCENT = 12;
    
    private string _fullName;
    private long _number;
    private int _workHours;
    private int _tariff;

    public Employee(string fullName, long number, int workHours, int tariff)
    {
        _fullName = fullName;
        _number = number;
        _workHours = workHours;
        _tariff = tariff;
    }

    public string FullName => _fullName;
    public long Number => _number;
    public int WorkHours => _workHours;
    public int Tariff => _tariff;
    public double Salary => GetSalary();

    private double GetSalary()
    {
        var salary = 0.0;
        switch (_workHours)
        {
            case <= LIMIT_HOURS:
                salary = _workHours * _tariff;
                break;
            case > LIMIT_HOURS:
                var overtime = (_workHours - LIMIT_HOURS) * (_tariff * 2);
                salary = (LIMIT_HOURS * _tariff) + overtime;
                break;
        }

        return salary - (salary * (INCOME_TAX_PERCENT / 100));
    }
}