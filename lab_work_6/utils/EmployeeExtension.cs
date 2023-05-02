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
    
    public static void SortBy(this List<Employee> list, SortType.SortTypes type)
    {
        list.Sort((employee1, employee2) => type switch
        { 
            SortType.SortTypes.BY_FULL_NAME => employee1.FullName.CompareTo(employee2.FullName),
            SortType.SortTypes.BY_NUMBER => employee1.Number.CompareTo(employee2.Number),
            SortType.SortTypes.BY_WORK_HOURS => employee1.WorkHours.CompareTo(employee2.WorkHours)
        });
    }
}