using System.Collections.Generic;
using System.Linq;
using lab_work_6.model;

namespace lab_work_6.utils;

public static class EmployeeExtension
{
    public static List<Employee> ToEmployeeList(this List<EmployeeDto> list)
    {
        return list.Select(e => e.ToEmployee()).ToList();
    }
    
    public static List<EmployeeDto> ToEmployeeDtoList(this List<Employee> list)
    {
        return list.Select(e => e.ToEmployeeDto()).ToList();
    }
    
    private static Employee ToEmployee(this EmployeeDto dto)
    {
        return new Employee(dto.Name, dto.Number, dto.Hours, dto.Tariff);
    }
    
    private static EmployeeDto ToEmployeeDto(this Employee employee)
    {
        return new EmployeeDto(employee.FullName, employee.Number, employee.WorkHours, employee.Tariff);
    }
}