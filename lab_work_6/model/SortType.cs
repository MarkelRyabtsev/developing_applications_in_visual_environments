namespace lab_work_6.model;

public class SortType
{
    public SortTypes SortTypeValue { get; private set; }
    
    public string Name => GetName();

    public SortType(SortTypes sortType)
    {
        SortTypeValue = sortType;
    }
    
    public enum SortTypes
    {
        BY_FULL_NAME,
        BY_NUMBER,
        BY_WORK_HOURS,
    }

    private string GetName() => SortTypeValue switch
    {
        SortTypes.BY_FULL_NAME => "By Fullname",
        SortTypes.BY_NUMBER => "By number",
        SortTypes.BY_WORK_HOURS => "By work hours"
    };
}