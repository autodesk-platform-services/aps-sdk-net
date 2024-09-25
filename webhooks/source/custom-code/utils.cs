using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Autodesk.Webhooks.Model;

namespace Autodesk.Webhooks.Model
{
    public static class Utils
    {
        public static string GetEnumString<T>(T enumValue) where T : Enum
        {
            var fieldInfo = typeof(T).GetField(enumValue.ToString());
            var attribute = fieldInfo?.GetCustomAttribute<EnumMemberAttribute>();

            return attribute?.Value ?? enumValue.ToString();
        }

    }

}