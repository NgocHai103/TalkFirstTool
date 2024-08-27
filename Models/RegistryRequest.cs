namespace TF_ClassRegistry.Models;

public class RegistryRequest
{
    public Guid Id { get; set; }

    public string Key { get; set; }

    public string Time { get; set; }

    public DayOfWeek Date { get; set; }

    public Guid SyllabusId { get; set; }
}
