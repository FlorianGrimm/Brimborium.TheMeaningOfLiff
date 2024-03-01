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
            // System.Console.Out.WriteLine($"dict[{i}] = new FullNamePart({i},[{csvName}]);");
        }
        NamePart namePartOptional = new("Optional", "optional", "NoValue", "NoDatum", "", "NoDatum");
        NamePart namePartValue = new("Value", "value", "Value", "ValueDatum<V>", "V", "ValueDatumOfV");
        NamePart namePartFailure = new("Failure", "failure", "Failure", "FailureDatum<F>", "F", "FailureDatumOfF");
        NamePart namePartError = new("Error", "error", "Error", "ErrorDatum", "", "ErrorDatum");
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
                fullNamePart.ArgName = fullNamePart.Parts[0].ArgName;
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
                fullNamePart.ArgName = csvParts[0..1].ToLower() + csvParts[1..^0];
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
            if (fullNamePart.Parts.Length == 1) {
            } else {
                StringBuilder sb = new();
                //System.Console.WriteLine(fullNamePart.FileName);
                //System.Console.WriteLine(fullNamePart.ClassName);
                sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
                sb.AppendLine("");
                sb.Append("public enum ").Append(fullNamePart.ModeName).Append(" { ");
                foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                    sb.Append(namePart.Item.EnumName);
                    if (!namePart.isLast) { sb.Append(", "); }
                }
                sb.Append(" }").AppendLine();
                sb.AppendLine("");
                sb.AppendLine("[DebuggerNonUserCode]");
                sb.AppendLine("""[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]""");
                sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, "(");
                sb.AppendLine("    ", fullNamePart.ModeName, " Mode,");
                foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("    ", namePart.Item.ClassName, " ", namePart.Item.PartName, namePart.isLast ? "" : ",");
                }
                sb.AppendLine("){");
                sb.AppendLine("    private string GetDebuggerDisplay() => this.ToString();");
                sb.AppendLine("");
                sb.AppendLine("    public string? Meaning => (this.Mode) switch {");
                foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("        ", fullNamePart.ModeName, ".", namePart.Item.EnumName, " => this.", namePart.Item.PartName, ".Meaning,");
                }
                sb.AppendLine("        _ => default");
                sb.AppendLine("    };");
                sb.AppendLine("");
                sb.AppendLine("    public long LogicalTimestamp => (this.Mode) switch {");
                foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("        ", fullNamePart.ModeName, ".", namePart.Item.EnumName, " => this.", namePart.Item.PartName, ".LogicalTimestamp,");
                }
                sb.AppendLine("        _ => 0");
                sb.AppendLine("    };");

                sb.AppendLine("}");
                System.IO.File.WriteAllText(
                    System.IO.Path.Combine(targetPath, $"{fullNamePart.FileName}.cs"),
                    sb.ToString());
            }
        }

        foreach (var fullNamePart in listFullNamePart) {
            if (fullNamePart.Parts.Length == 1) {
            } else {
                StringBuilder sb = new();
                sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
                sb.AppendLine("");
                sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, "{");
                foreach (var (extractType, downgradeType) in fullNamePart.ListDowngrade) {

                    sb.AppendLine("    public bool TryGet", extractType.Parts[0].PartName, "(out ", extractType.ClassName, " ", extractType.ArgName, "){");
                    sb.AppendLine("        if (this.Mode == ", fullNamePart.ModeName, ".", extractType.Parts[0].EnumName, ") {");
                    sb.AppendLine("            ", extractType.ArgName, " = this.", extractType.Parts[0].PartName, ";");
                    sb.AppendLine("            return true;");
                    sb.AppendLine("        } else {");
                    sb.AppendLine("            ", extractType.ArgName, " = default;");
                    sb.AppendLine("            return false;");
                    sb.AppendLine("        }");
                    sb.AppendLine("    }");
                    sb.AppendLine("");

                    sb.AppendLine("    public bool TryGet", extractType.Parts[0].PartName, "(out ", extractType.ClassName, " ", extractType.ArgName, "Datum, out ", downgradeType.ClassName, " ", downgradeType.ArgName, "Datum){");
                    sb.AppendLine("        if (this.Mode == ", fullNamePart.ModeName, ".", extractType.Parts[0].EnumName, ") {");
                    sb.AppendLine("            ", extractType.ArgName, "Datum = this.", extractType.Parts[0].PartName, ";");
                    sb.AppendLine("            ", downgradeType.ArgName, "Datum = default;");
                    sb.AppendLine("            return true;");
                    sb.AppendLine("        } else {");
                    sb.AppendLine("            ", extractType.ArgName, "Datum = default;");
                    if (downgradeType.Parts.Length == 1) {
                        sb.AppendLine("            ", downgradeType.ArgName, "Datum = this.", downgradeType.Parts[0].PartName, ";");
                    } else {
                        sb.AppendLine("            ", downgradeType.ArgName, "Datum = new ", downgradeType.ClassName, "(");
                        sb.AppendLine("                ((this.Mode) switch {");
                        foreach (var downgradeTypeIndex in downgradeType.Parts.ToListIndex()) {
                            sb.AppendLine("                    ", fullNamePart.ModeName, ".", downgradeTypeIndex.Item.EnumName, " => ", downgradeType.ModeName, ".", downgradeTypeIndex.Item.EnumName, ",");
                        }
                        sb.AppendLine("                    _ => throw new InvalidOperationException()");
                        sb.AppendLine("                }),");
                        foreach (var downgradeTypeIndex in downgradeType.Parts.ToListIndex()) {
                            sb.AppendLine("                this.", downgradeTypeIndex.Item.PartName, downgradeTypeIndex.isLast ? "" : ",");
                        }
                        sb.AppendLine("                );");
                    }
                    sb.AppendLine("            return false;");
                    sb.AppendLine("        }");
                    sb.AppendLine("    }");
                    sb.AppendLine("");
                }
                sb.AppendLine("}");
                System.IO.File.WriteAllText(
                    System.IO.Path.Combine(targetPath, $"{fullNamePart.FileName}.Downgrade.cs"),
                    sb.ToString());
            }
        }

        // construction

        foreach (var fullNamePart in listFullNamePart) {
            StringBuilder sb = new();
            // System.Console.WriteLine(fullNamePart.FileName);
            // System.Console.WriteLine(fullNamePart.ClassName);
            sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
            sb.AppendLine("");
            sb.AppendLine("public static partial class Datum {");

            if (fullNamePart.Parts.Length == 1) {
            } else {
                //foreach (var itemDowngrade in fullNamePart.ListDowngrade.ToListIndex()) {
                foreach (var partIndex in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("    public static ", fullNamePart.ClassName, " As", fullNamePart.ClassName, "(");
                    sb.AppendLine("        this ", partIndex.Item.ClassName, " ", partIndex.Item.ArgName);
                    sb.AppendLine("    ) {");
                    sb.AppendLine("        return new ", fullNamePart.ClassName, "(");
                    sb.AppendLine("           ", fullNamePart.ModeName, ".", partIndex.Item.EnumName, ",");
                    foreach (var partIndexParameter in fullNamePart.Parts.ToListIndex()) {
                        if (partIndex.index == partIndexParameter.index) {
                            sb.AppendLine("           ", partIndexParameter.Item.ArgName, partIndexParameter.isLast ? "" : ",");
                        } else {
                            sb.AppendLine("           default ", partIndexParameter.isLast ? "" : ",");
                        }
                    }
                    sb.AppendLine("        );");
                    sb.AppendLine("    }");
                }
                /*
                public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
                    this NoDatum Optional
                    //ValueDatum<V> Value,
                    //FailureDatum<F> Failure,
                    //ErrorDatum Error
                    ) {
                    return new OptionalValueFailureErrorDatum<V, F>(
                        OptionalValueFailureErrorMode.NoValue,
                        Optional,
                        default,
                        default,
                        default
                        );
                }
                */
            }
            sb.AppendLine("}");
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(targetPath, $"Datum.{fullNamePart.FileName}.Construction.cs"),
                sb.ToString());
        }

        foreach (var fullNamePart in listFullNamePart) {
            StringBuilder sb = new();
            // System.Console.WriteLine(fullNamePart.FileName);
            // System.Console.WriteLine(fullNamePart.ClassName);
            sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
            sb.AppendLine("");
            sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, " {");

            if (fullNamePart.Parts.Length == 1) {
            } else {
                foreach (var partIndex in fullNamePart.Parts.ToListIndex()) {
                    
                    sb.AppendLine("     public static explicit operator ", partIndex.Item.ClassName,"(", fullNamePart.ClassName, " value) {");
                    sb.AppendLine("        return (value.Mode switch {");
                    sb.AppendLine("            ",fullNamePart.ModeName,".",partIndex.Item.EnumName," => value.",partIndex.Item.PartName,",");
                    sb.AppendLine("            _ => throw new InvalidCastException()");
                    sb.AppendLine("        });");
                    sb.AppendLine("    }");
                }

                //foreach (var itemDowngrade in fullNamePart.ListDowngrade.ToListIndex()) {
                //foreach (var partIndex in fullNamePart.Parts.ToListIndex()) {
                //    sb.AppendLine("    public static ", fullNamePart.ClassName, " As", fullNamePart.ClassName, "(");
                //    sb.AppendLine("        this ", partIndex.Item.ClassName, " ", partIndex.Item.ArgName);
                //    sb.AppendLine("    ) {");
                //    sb.AppendLine("        return new ", fullNamePart.ClassName, "(");
                //    sb.AppendLine("           ", fullNamePart.ModeName, ".", partIndex.Item.EnumName, ",");
                //    foreach (var partIndexParameter in fullNamePart.Parts.ToListIndex()) {
                //        if (partIndex.index == partIndexParameter.index) {
                //            sb.AppendLine("           ", partIndexParameter.Item.ArgName, partIndexParameter.isLast ? "" : ",");
                //        } else {
                //            sb.AppendLine("           default ", partIndexParameter.isLast ? "" : ",");
                //        }
                //    }
                //    sb.AppendLine("        );");
                //    sb.AppendLine("    }");
                //}
                /*
                */
            }
            sb.AppendLine("}");
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(targetPath, $"{fullNamePart.FileName}.Operator.cs"),
                sb.ToString());
        }

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
    }

    public static string GetFolder([CallerFilePath] string? filePath = default) {
        return System.IO.Path.GetDirectoryName(filePath) ?? string.Empty;
    }
}
record NamePart(string PartName, string ArgName, string EnumName, string ClassName, string GenericTypeArgName, string FileName) {
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

    public string ArgName { get; set; } = string.Empty;

    public string ModeName { get; set; } = string.Empty;

    public List<(FullNamePart extractType, FullNamePart downgradeType)> ListDowngrade { get; } = new();

    public override string ToString() {
        var parts = string.Join(", ", this.Parts.Select(i => i.PartName));
        return $"Parts: {parts}";
    }
}

public static class Extensions {
    public static List<ItemIndex<T>> ToListIndex<T>(this IEnumerable<T> items) {
        var list = (items is List<T> l) ? l : items.ToList();
        List<ItemIndex<T>> result = new();
        for (int i = 0; i < list.Count; i++) {
            result.Add(new ItemIndex<T>(list[i], i, i == 0, i == (list.Count - 1)));
        }
        return result;
    }

    public static StringBuilder Append(this StringBuilder that, params string[] value) {
        foreach (var item in value) {
            that.Append(item);
        }
        return that;
    }

    public static StringBuilder AppendLine(this StringBuilder that, params string[] value) {
        foreach (var item in value) {
            that.Append(item);
        }
        return that.AppendLine();
    }
}
public record struct ItemIndex<T>(T Item, int index, bool isFirst, bool isLast);