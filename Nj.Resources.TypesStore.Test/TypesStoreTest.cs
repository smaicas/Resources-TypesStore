namespace Nj.Resources.TypesStore.Test;

public class MyTestAttribute : Attribute { }

public class MyClass1 { }

[MyTest]
public class MyClass2 { }

public class MyClass3 { }

public class TypesStoreTest
{
    [Fact]
    public void AttributesStore_IsCreatedWithAllTypesFromAssembly()
    {
        // Arrange
        var store = new AttributesStore<MyTestAttribute>();

        // Act
        var types = store.GetTypes();

        // Assert
        Assert.Equal(1, types.Count());
        Assert.Same(typeof(MyClass2), types.First());
    }
}