using System.Collections.Generic;
using lab_work_6.model;
using Newtonsoft.Json;

namespace lab_work_6.utils;

public static class JsonExtension
{
    public static T ToObject<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
    
    public static string ToJson(this List<EmployeeDto> items)
    {
        return JsonConvert.SerializeObject(items);
    }
}