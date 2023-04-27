using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UserApp.Shared.Tools;

public static class ObjectPrinter
{
    public static void PrintObject(object @object)
    {
        Type type = @object.GetType();
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Default | BindingFlags.Instance);

        foreach (var property in properties)
        {
            Console.WriteLine("{0} = {1}", property.Name, property.GetValue(@object, null));
        }
    }
}