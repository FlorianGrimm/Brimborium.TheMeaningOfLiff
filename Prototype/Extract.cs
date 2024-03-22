using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype;
internal class Extract {
    public static List<string> Get(List<Type> listType) {
        var result = new List<string>();
        foreach (var type in listType.Where(t=>t.IsPublic).Where(t=>!t.IsEnum).OrderBy(t=>t.FullName??string.Empty)) {
            Get(type, result);
        }
        return result;
    }
    public static void Get(Type type, List<string> result) {
        var fullName = type.FullName;
        result.Add($"T:{fullName}");
        foreach (var member in type.GetMembers().OrderBy(m => m.Name)) {
            result.Add($"M:  {fullName} {member.MemberType} {member.Name}");
        }
    }
}
