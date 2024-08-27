using TF_ClassRegistry.Models;

namespace TF_ClassRegistry.Data;

public static class StaticData
{
    public static readonly IDictionary<string, string> Users = new Dictionary<string, string>();
    public static readonly IDictionary<string, string> Tokens = new Dictionary<string, string>();
    public static readonly IDictionary<string, List<ClassInfo>> Classes = new Dictionary<string, List<ClassInfo>>();

    public static readonly IDictionary<string, List<RegistryResult>> RegistryResults = new Dictionary<string, List<RegistryResult>>();
}
