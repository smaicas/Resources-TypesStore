using System.Reflection;

namespace Nj.Resources.TypesStore;
public class AttributesStore<TAttribute> : TypesStore where TAttribute : Attribute
{
    private readonly HashSet<Type> _types;


    public AttributesStore()
    {
        Type[] types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<TAttribute>() != null)
            .ToArray();
        _types = new HashSet<Type>(types);
    }
    public IEnumerable<Type> GetTypes()
    {
        return _types;
    }
    public override void Add(params Type[] types) => _types.UnionWith(new HashSet<Type>(types.Where(t => t.GetCustomAttribute<TAttribute>() != null)));

}
