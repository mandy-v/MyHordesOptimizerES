using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace MyHordesOptimizerApi.Extensions
{
    public static class ObjectExtensions
    {
        public static void UpdateItem<T>(this T item, T clone)
        {
            foreach(var prop in typeof(T).GetProperties())
            {
                if(!prop.GetCustomAttributes().Any(attr => attr.GetType() == typeof(KeyAttribute)))
                {
                    var value = prop.GetValue(clone);
                    prop.SetValue(item, value);
                }
            }
        }
    }
}
