using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Autodesk.Oss.Model
{

    public static class Utils
    {
        internal static string GetObjectStatusEnumString<T>(T enumVal)
        {
            var enumType = typeof(T);
            var memInfo = enumType.GetMember(enumVal?.ToString());
            var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            if (attr != null)
            {
                return attr.Value;
            }
            return null;
        }

    }

}