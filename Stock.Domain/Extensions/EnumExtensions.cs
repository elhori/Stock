using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var enumType = value.GetType();
        var enumValueName = Enum.GetName(enumType, value)!;

        MemberInfo memberInfo = enumType.GetField(enumValueName)!;
        var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>()!;

        return displayAttribute?.Name ?? enumValueName;
    }
}