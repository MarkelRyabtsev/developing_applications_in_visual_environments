using Newtonsoft.Json;

namespace lab_work_6.model;

public class Employee
{
    private const int LIMIT_HOURS = 144;
    private const int INCOME_TAX_PERCENT = 12;
    
    private string _fullName;
    private long _number;
    private int _workHours;
    private int _tariff;

    [JsonProperty("full_name")]
    public string FullName
    {
        get => _fullName;
        set => _fullName = value;
    }
    
    [JsonProperty("number")]
    public long Number
    {
        get => _number;
        set => _number = value;
    }
    
    [JsonProperty("work_hours")]
    public int WorkHours{
        get => _workHours;
        set => _workHours = value;
    }
    
    [JsonProperty("tariff")]
    public int Tariff{
        get => _tariff;
        set => _tariff = value;
    }
    
    [JsonIgnore]
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