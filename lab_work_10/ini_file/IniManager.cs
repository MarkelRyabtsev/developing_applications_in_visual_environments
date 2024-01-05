using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using IniFile;

namespace lab_work_10.ini_file;

public class IniManager
{
    private Ini _ini;
    
    private string _path = null;
    
    public IniManager(string path)
    {
        _path = path;
        _ini = new Ini();
    }
 
    public string GetParam(IniSection section, IniKey key)
    {
        try
        {
            var ini = new Ini(_path);
            return ini[section.ToString()][key.ToString()];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "";
        }
    }
 
    public void SetParam(IniSection section, IniKey key, string value)
    {
        try
        {
            _ini.Add(new Section(section.ToString())
            {
                new Property(key.ToString(), value)
            });
            _ini.SaveTo(_path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

public enum IniKey
{
    LAST_VALUE
}

public enum IniSection
{
    MAIN
}