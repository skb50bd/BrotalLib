using System.Linq;

namespace Brotal.Extensions
{
    public static class UpdateState
    {
        public static void SetValuesFrom<T>(
            this T original, 
            T newObj) where T : class
        {
            foreach (var prop in original
                                    .GetType()
                                    .GetProperties()
                                    .Where(p => p.CanWrite))
                prop.SetValue(
                    original, 
                    prop.GetValue(newObj)
                );
        }
    }
}
