using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Autodesk.Webhooks.Model;

namespace Autodesk.Webhooks.Model
{
    public static class Utils
    {

        public static Dictionary<Scopes, string> SetScope(this Dictionary<Scopes, string> scope, Scopes scopeEnum, string value)
        {
            if (scope == null)
                scope = new Dictionary<Scopes, string>();

            var scopeEnumString = Utils.GetEnumString(scopeEnum);
            scope.Add(scopeEnum, value);
            return scope;
        }

        internal static string GetEnumString<T>(T enumVal)
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