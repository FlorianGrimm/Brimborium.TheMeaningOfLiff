using System.Runtime.CompilerServices;
using System.Text;

namespace Generate;

public class Program {
    public static void Main(string[] args) {
        var targetPath = System.IO.Path.GetFullPath(
            System.IO.Path.Combine(GetFolder(), @"..\Generated")
            );
        Console.WriteLine(targetPath);
        /*
         namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueFailureErrorDatumMode { NoValue, Success, Error, Failure }

[DebuggerNonUserCode]
[method: JsonConstructor]
public readonly partial record struct OptionalValueFailureErrorDatum<V, F>(
         */
        for (int i = 1; i < 16; i++) {
            List<string> list = new();
            if ((i & 1) == 1) { list.Add("namePartOptional"); }
            if (((i >> 1) & 1) == 1) { list.Add("namePartValue"); }
            if (((i >> 2) & 1) == 1) { list.Add("namePartFailure"); }
            if (((i >> 3) & 1) == 1) { list.Add("namePartError"); }
            var csvName = string.Join(", ", list);
            System.Console.Out.WriteLine($"dict[{i}] = new FullNamePart({i},[{csvName}]);");
        }
        NamePart namePartOptional = new("Optional", "NoValue", "NoDatum", "", "NoDatum");
        NamePart namePartValue = new("Value", "Success", "ValueDatum<V>", "V", "ValueDatumOfV");
        NamePart namePartFailure = new("Failure", "Failure", "FailureDatum<F>", "F", "FailureDatumOfF");
        NamePart namePartError = new("Error", "Error", "ErrorDatum", "", "ErrorDatum");
        List<NamePart> listAllParts = [
            namePartOptional,
            namePartValue,
            namePartFailure,
            namePartError
        ];
        Dictionary<int, FullNamePart> dict = new();
        dict[1] = new FullNamePart(1, [namePartOptional]);
        dict[2] = new FullNamePart(2, [namePartValue]);
        dict[3] = new FullNamePart(3, [namePartOptional, namePartValue]);
        dict[4] = new FullNamePart(4, [namePartFailure]);
        dict[5] = new FullNamePart(5, [namePartOptional, namePartFailure]);
        dict[6] = new FullNamePart(6, [namePartValue, namePartFailure]);
        dict[7] = new FullNamePart(7, [namePartOptional, namePartValue, namePartFailure]);
        dict[8] = new FullNamePart(8, [namePartError]);
        dict[9] = new FullNamePart(9, [namePartOptional, namePartError]);
        dict[10] = new FullNamePart(10, [namePartValue, namePartError]);
        dict[11] = new FullNamePart(11, [namePartOptional, namePartValue, namePartError]);
        dict[12] = new FullNamePart(12, [namePartFailure, namePartError]);
        dict[13] = new FullNamePart(13, [namePartOptional, namePartFailure, namePartError]);
        dict[14] = new FullNamePart(14, [namePartValue, namePartFailure, namePartError]);
        dict[15] = new FullNamePart(15, [namePartOptional, namePartValue, namePartFailure, namePartError]);
        var listFullNamePart = dict.Keys.OrderBy(i => i).Select(i => dict[i]).ToList();
        foreach (var fullNamePart in listFullNamePart) {
            if (fullNamePart.Parts.Length == 1) {
                fullNamePart.ClassName = fullNamePart.Parts[0].ClassName;
                fullNamePart.FileName = fullNamePart.Parts[0].FileName;
            } else {
                var csvParts = string.Join("", fullNamePart.Parts.Select(i => i.PartName));
                var csvGenericTypeArgNames = string.Join(", ", fullNamePart.Parts.Where(i => i.GenericTypeArgName != "").Select(i => i.GenericTypeArgName));
                var filenameSuffix = string.Join("And", fullNamePart.Parts.Where(i => i.GenericTypeArgName != "").Select(i => i.GenericTypeArgName));
                fullNamePart.ModeName = $"{csvParts}Mode";
                if (string.IsNullOrEmpty(csvGenericTypeArgNames)) {
                    fullNamePart.FileName = $"{csvParts}Datum";
                    fullNamePart.ClassName = $"{csvParts}Datum";
                } else {
                    fullNamePart.FileName = $"{csvParts}DatumOf{filenameSuffix}";
                    fullNamePart.ClassName = $"{csvParts}Datum<{csvGenericTypeArgNames}>";
                }
            }

            foreach (var bit in new int[] { 1, 2, 4, 8 }) {
                if ((fullNamePart.iType & bit) == bit) {
                    int iTypeDowngrade = (fullNamePart.iType & ~bit);
                    if (iTypeDowngrade != 0) {
                        fullNamePart.ListDowngrade.Add((dict[bit], dict[iTypeDowngrade]));
                    }
                }
            }
        }
        foreach (var fullNamePart in listFullNamePart) {
            /*
            System.Console.WriteLine($"{fullNamePart.iType}");
            System.Console.WriteLine(string.Join(", ", fullNamePart.Parts.Select(i => i.PartName)));
            System.Console.WriteLine(fullNamePart.ClassName);
            System.Console.WriteLine(string.Join(", ", fullNamePart.ListDowngrade.Select(l => $"{l.extractType.ClassName}-{l.downgradeType.ClassName}")));
            System.Console.WriteLine("");
            */
            if (fullNamePart.Parts.Length == 1) { continue; }
            System.Console.WriteLine(fullNamePart.FileName);
            System.Console.WriteLine(fullNamePart.ClassName);
            StringBuilder sb = new();
            sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
            sb.AppendLine("");
            sb.AppendLine("// public readonly partial record struct OptionalValueDatum<T>(");
            /*
            public enum OptionalValueDatumMode { NoValue, Success }

            [DebuggerNonUserCode]
            [method: JsonConstructor]
            public readonly partial record struct OptionalValueDatum<T>(
                    OptionalValueDatumMode Mode,
                    [property: AllowNull][AllowNull] NoDatum NoValue,
                    [property: AllowNull][AllowNull] ValueDatum<T> ValueDatum
                )
             */
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(targetPath, $"{fullNamePart.FileName}.cs"),
                sb.ToString()                );

        }
    }

    public static string GetFolder([CallerFilePath] string? filePath = default) {
        return System.IO.Path.GetDirectoryName(filePath) ?? string.Empty;
    }
}
record NamePart(string PartName, string EnumName, string ClassName, string GenericTypeArgName, string FileName) {
    public override string ToString() {
        return this.PartName;
    }

}
record FullNamePart(int iType, NamePart[] Parts) {
    //public string GetName() {
    //    var parts = string.Join(", ", this.Parts.Select(i => i.PartName));
    //    return $"{parts}Datum";
    //}

    public string FileName { get; set; } = string.Empty;

    public string ClassName { get; set; } = string.Empty;
    public string ModeName { get; set; } = string.Empty;

    public List<(FullNamePart extractType, FullNamePart downgradeType)> ListDowngrade { get; } = new();

    public override string ToString() {
        var parts = string.Join(", ", this.Parts.Select(i => i.PartName));
        return $"Parts: {parts}";
    }
}