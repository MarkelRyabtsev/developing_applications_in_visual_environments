using System;
using System.Collections.Generic;
using lab_work_7_func_module.functions;

namespace lab_work_7_func_module
{
    public static class MathFunctionList
    {
        public static List<Function> GetFunctionList()
        {
            return new List<Function>()
            {
                new Function1(),
                new Function2(),
                new Function3()
            };
        }
    }
}