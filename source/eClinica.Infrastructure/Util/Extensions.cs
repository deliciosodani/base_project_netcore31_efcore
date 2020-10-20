using System.Linq;
using System.Reflection;

namespace eClinica.Infrastructure.Util
{
    public static class Extensions
    {
        public static T GetValue<T>(this object src)
        {
            var prop = src?
                .GetType()
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Where(x => x.PropertyType == typeof(T))
                .First();

            var value = (T)prop?.GetValue(src, null);

            return value;
        }
    }
}
