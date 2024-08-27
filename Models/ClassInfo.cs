namespace TF_ClassRegistry.Models;

public class ClassInfo
{
    public Guid Id { get; set; }

    public string Key { get; set; }

    public string Time { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public Guid SyllabusId { get; set; }
}
