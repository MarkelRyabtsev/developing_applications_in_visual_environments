using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab_work_6.model;

public class EmployeeDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("number")]
    public long Number { get; set; }
    [JsonPropertyName("hours")]
    public int Hours { get; set; }
    [JsonPropertyName("tariff")]
    public int Tariff { get; set; }
    
    public EmployeeDto(string fullName, long number, int workHours, int tariff)
    {
        Name = fullName;
        Number = number;
        Hours = workHours;
        Tariff = tariff;
    }
}