namespace Nj.Resources.TypesStore;
public abstract class TypesStore
{
    private readonly HashSet<Type> _objectList = new();

    public virtual void Add(params Type[] types) => _objectList.UnionWith(new HashSet<Type>(types));

    public virtual HashSet<Type> GetTypes() => _objectList;
}