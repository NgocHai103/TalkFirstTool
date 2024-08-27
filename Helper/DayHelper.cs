namespace TF_ClassRegistry.Helper;

public static class DayHelper
{
    public static DateTime GetMondayOfCurrentWeek(DateTime date)
    {
        var daysToMonday = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
        return date.AddDays(-daysToMonday);
    }
    public static DateTime GetTuesdayOfCurrentWeek(DateTime date)
    {
        var monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(1);
    }

    public static DateTime GetWednesdayOfCurrentWeek(DateTime date)
    {
        DateTime monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(2);
    }

    public static DateTime GetThursdayOfCurrentWeek(DateTime date)
    {
        DateTime monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(3);
    }

    public static DateTime GetFridayOfCurrentWeek(DateTime date)
    {
        DateTime monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(4);
    }

    public static DateTime GetSaturdayOfCurrentWeek(DateTime date)
    {
        DateTime monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(5);
    }

    public static DateTime GetSundayOfCurrentWeek(DateTime date)
    {
        DateTime monday = GetMondayOfCurrentWeek(date);
        return monday.AddDays(6);
    }
}
