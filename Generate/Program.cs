using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Generate;

public class Program {

    private const int iTypeOptional = 0x01;
    private const int iTypeValue = 0x02;
    private const int iTypeFailure = 0x04;
    private const int iTypeError = 0x08;
    private const int iTypeValueError = 0x02 | 0x08;

    public static void Main(string[] args) {
        var targetPath = System.IO.Path.GetFullPath(
            System.IO.Path.Combine(GetFolder(), @"..\Generated")
            );
        //Console.WriteLine(targetPath);
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
            //System.Console.Out.WriteLine($"dict[{i}] = new FullNamePart({i},[{csvName}]);");
        }
        NamePart namePartOptional = new(iTypeOptional, typeof(Brimborium.TheMeaningOfLiff.NoDatum), "Optional", "optional", "NoValue", "NoDatum", "", "NoDatum");
        NamePart namePartValue = new(iTypeValue, typeof(Brimborium.TheMeaningOfLiff.ValueDatum<>), "Value", "value", "Value", "ValueDatum<V>", "V", "ValueDatumOfV");
        NamePart namePartFailure = new(iTypeFailure, typeof(Brimborium.TheMeaningOfLiff.FailureDatum<>), "Failure", "failure", "Failure", "FailureDatum<F>", "F", "FailureDatumOfF");
        NamePart namePartError = new(iTypeError, typeof(Brimborium.TheMeaningOfLiff.ErrorDatum), "Error", "error", "Error", "ErrorDatum", "", "ErrorDatum");

        List<NamePart> listAllParts = [
            namePartOptional,
            namePartValue,
            namePartFailure,
            namePartError
        ];


        //string? Meaning = default,    long LogicalTimestamp = 0)

        NullabilityInfoContext nullabilityInfoContext = new();

        foreach (var part in listAllParts) {
            var constructor = part.Type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            part.Parameters.AddRange(
                constructor.GetParameters().Select(p => {
                    var nullabilityInfo = nullabilityInfoContext.Create(p);
                    var parameterTypeName = p.ParameterType.FullName ?? p.ParameterType.Name;
                    //p.GetCustomAttributes().Any(a=>a.GetType().FullName == "")
                    var nullable = nullabilityInfo.ReadState == NullabilityState.Nullable;
                    if (p.HasDefaultValue) {
                        return new Parameter(
                            parameterTypeName,
                            nullable,
                            p.Name!,
                            p.HasDefaultValue,
                            p.DefaultValue);
                    } else {
                        return new Parameter(
                            parameterTypeName,
                            nullable,
                            p.Name!,
                            p.HasDefaultValue,
                            null);
                    }
                }));
            foreach (var itemIndex in part.Parameters.ToListIndex()) {
                var parameter = itemIndex.Item;
                if (string.Equals("Meaning", parameter.Name, StringComparison.OrdinalIgnoreCase)) {
                    parameter.ParameterMode = ParameterMode.Meaning;
                } else if (string.Equals("LogicalTimestamp", parameter.Name, StringComparison.OrdinalIgnoreCase)) {
                    parameter.ParameterMode = ParameterMode.LogicalTimestamp;
                } else if (string.Equals("IsLogged", parameter.Name, StringComparison.OrdinalIgnoreCase)) {
                    parameter.ParameterMode = ParameterMode.IsLogged;
                } else if (itemIndex.index == 0) {
                    parameter.ParameterMode = ParameterMode.Value;
                } else {
                    parameter.ParameterMode = ParameterMode.AdditionalValue;
                }
            }
        }

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
            //foreach (var part in fullNamePart.Parts) {
            //    if (!string.IsNullOrEmpty(part.GenericTypeArgName)) {
            //        if (!fullNamePart.ListGenericArgument.Contains(part.GenericTypeArgName)) {
            //            fullNamePart.ListGenericArgument.Add(part.GenericTypeArgName);
            //        }
            //    }
            //}
            if (fullNamePart.Parts.Length == 1) {
                var part0 = fullNamePart.Parts[0];
                fullNamePart.ClassName = part0.ClassName;
                var arrClassNamePart = part0.ClassName.Split('<', '>');
                fullNamePart.ClassNameNoGenericArgument = arrClassNamePart.First();
                fullNamePart.ListGenericArgument.AddRange(
                    (arrClassNamePart.Skip(1).FirstOrDefault() ?? "").Split(",").Select(s => s.Trim()).Where(s=>s.Length>0)
                    );
                fullNamePart.FileName = part0.FileName;
                fullNamePart.ArgName = part0.ArgName;
                fullNamePart.Parameters.AddRange(part0.Parameters);
            } else {
                var csvParts = string.Join("", fullNamePart.Parts.Select(i => i.PartName));
                foreach (var s in fullNamePart.Parts.Where(i => i.GenericTypeArgName != "").Select(i => i.GenericTypeArgName).Where(s => s.Length > 0)) {
                    if (fullNamePart.ListGenericArgument.Contains(s)) {
                        //
                    } else { 
                        fullNamePart.ListGenericArgument.Add(s);
                    }

                }
                var csvGenericTypeArgNames = string.Join(", ", fullNamePart.ListGenericArgument);
                var filenameSuffix = string.Join("And", fullNamePart.ListGenericArgument);
                fullNamePart.ModeTypeName = $"{csvParts}Mode";
                if (string.IsNullOrEmpty(csvGenericTypeArgNames)) {
                    fullNamePart.FileName = $"{csvParts}Datum";
                    fullNamePart.ClassName = $"{csvParts}Datum";
                    fullNamePart.ClassNameNoGenericArgument = $"{csvParts}Datum";
                } else {
                    fullNamePart.FileName = $"{csvParts}DatumOf{filenameSuffix}";
                    fullNamePart.ClassName = $"{csvParts}Datum<{csvGenericTypeArgNames}>";
                    fullNamePart.ClassNameNoGenericArgument = $"{csvParts}Datum";
                }
                fullNamePart.ArgName = csvParts[0..1].ToLower() + csvParts[1..^0];
                fullNamePart.Parameters.Add(new Parameter(fullNamePart.ModeTypeName, false, "Mode", false, null) { ParameterMode = ParameterMode.Mode });
                foreach (var namePart in fullNamePart.Parts) {
                    fullNamePart.Parameters.Add(new Parameter(namePart.ClassName, false, namePart.PartName, false, null) { ParameterMode = ParameterMode.CaseValue });
                }
            }

            foreach (var bit in new int[] { 1, 2, 4, 8 }) {
                if (dict.TryGetValue(bit, out var fullNamePartBit)) {
                    if ((fullNamePart.iType & bit) == bit) {
                        int iTypeDowngrade = (fullNamePart.iType & ~bit);
                        if (iTypeDowngrade != 0) {
                            fullNamePart.ListDowngrade.Add(new Downgrade(fullNamePartBit, dict[iTypeDowngrade]));
                        }
                    }
                }
            }
            foreach (var bit in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }) {
                if (dict.TryGetValue(bit, out var fullNamePartBit)) {
                    if ((fullNamePart.iType & ~bit) == fullNamePart.iType) {
                        var iTypeUpgrade = (fullNamePart.iType | bit);
                        if (dict.TryGetValue(iTypeUpgrade, out var fullNamePartUpgrade)) {
                            fullNamePart.ListUpgrade.Add(new Upgrade(fullNamePartBit, fullNamePartUpgrade));
                        }
                    }
                }
            }
        }
        Dictionary<string, StringBuilder> dictFile = new();

        // generated 1 type

        foreach (var fullNamePart in listFullNamePart) {
            if (fullNamePart.Parts.Length == 1) {
                // System.Console.WriteLine(fullNamePart.ClassName);
            } else {
                StringBuilder sb = getFile($"{fullNamePart.FileName}.cs");
                //System.Console.WriteLine(fullNamePart.FileName);
                //System.Console.WriteLine(fullNamePart.ClassName);
                sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
                sb.AppendLine("");
                sb.AppendLine("// generated 1 type");
                sb.AppendLine("");
                sb.Append("public enum ").Append(fullNamePart.ModeTypeName).Append(" { ");
                foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                    sb.Append(namePart.Item.EnumValueName);
                    if (!namePart.isLast) { sb.Append(", "); }
                }
                sb.Append(" }").AppendLine();
                sb.AppendLine("");
                sb.AppendLine("[DebuggerNonUserCode]");
                sb.AppendLine("""[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]""");
                sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, "(");
                foreach (var parameter in fullNamePart.Parameters.ToListIndex()) {
                    sb.Append("    ").Append(parameter.Item.ToString()).Append(parameter.isLast ? "" : ",").AppendLine();
                }
                //sb.AppendLine("    ", fullNamePart.ModeTypeName, " Mode,");
                //foreach (var namePart in fullNamePart.Parts.ToListIndex()) {
                //    sb.AppendLine("    ", namePart.Item.ClassName, " ", namePart.Item.PartName, namePart.isLast ? "" : ",");
                //}
                sb.AppendLine(") : IWithMeaning, ILogicalTimestamp {");
                sb.AppendLine("    private string GetDebuggerDisplay() => this.ToString();");
                sb.AppendLine();

                sb.AppendLine($"    public string? Meaning => this.Mode switch {{");
                foreach (var part in fullNamePart.Parts) {
                    sb.AppendLine($"        {fullNamePart.ModeTypeName}.{part.EnumValueName} => this.{part.PartName}.Meaning,");
                }
                sb.AppendLine($"        _ => default");
                sb.AppendLine($"    }};");
                sb.AppendLine();

                sb.AppendLine($"    public long LogicalTimestamp => this.Mode switch {{");
                foreach (var part in fullNamePart.Parts) {
                    sb.AppendLine($"        {fullNamePart.ModeTypeName}.{part.EnumValueName} => this.{part.PartName}.LogicalTimestamp,");
                }
                sb.AppendLine($"        _ => default");
                sb.AppendLine($"    }};");
                sb.AppendLine();

                sb.AppendLine("}");
            }
        }

        // generated 2 Downgrade

        foreach (var fullNamePart in listFullNamePart) {
            if (fullNamePart.Parts.Length == 1) {
            } else {
                StringBuilder sb = getFile($"{fullNamePart.FileName}.Downgrade.cs");

                //System.Console.WriteLine(fullNamePart.FileName);
                //System.Console.WriteLine(fullNamePart.ClassName);
                sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
                sb.AppendLine("");
                sb.AppendLine("// generated 2 Downgrade");
                sb.AppendLine("");
                sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, "{");
                foreach (var (extractType, downgradeType) in fullNamePart.ListDowngrade) {

                    sb.AppendLine("    public bool TryGet", extractType.Parts[0].PartName, "(out ", extractType.ClassName, " ", extractType.ArgName, "){");
                    sb.AppendLine("        if (this.Mode == ", fullNamePart.ModeTypeName, ".", extractType.Parts[0].EnumValueName, ") {");
                    sb.AppendLine("            ", extractType.ArgName, " = this.", extractType.Parts[0].PartName, ";");
                    sb.AppendLine("            return true;");
                    sb.AppendLine("        } else {");
                    sb.AppendLine("            ", extractType.ArgName, " = default;");
                    sb.AppendLine("            return false;");
                    sb.AppendLine("        }");
                    sb.AppendLine("    }");
                    sb.AppendLine("");

                    sb.AppendLine("    public bool TryGet", extractType.Parts[0].PartName, "(out ", extractType.ClassName, " ", extractType.ArgName, "Datum, out ", downgradeType.ClassName, " ", downgradeType.ArgName, "Datum){");
                    sb.AppendLine("        if (this.Mode == ", fullNamePart.ModeTypeName, ".", extractType.Parts[0].EnumValueName, ") {");
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
                            sb.AppendLine("                    ", fullNamePart.ModeTypeName, ".", downgradeTypeIndex.Item.EnumValueName, " => ", downgradeType.ModeTypeName, ".", downgradeTypeIndex.Item.EnumValueName, ",");
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
            }
        }

        // generated 3 Upgrade

        foreach (var fullNamePart in listFullNamePart) {
            if (fullNamePart.Parts.Length == 1) {
            } else {
                StringBuilder sb = getFile($"{fullNamePart.FileName}.Upgrade.cs");

                //System.Console.WriteLine(fullNamePart.FileName);
                //System.Console.WriteLine(fullNamePart.ClassName);
                sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
                sb.AppendLine("");
                sb.AppendLine("// generated 3 Upgrade");
                sb.AppendLine("");
                sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, "{");
                foreach (var (extractType, upgradeType) in fullNamePart.ListUpgrade) {
                    // sb.AppendLine($"//    extractType:{extractType.ClassName} upgradeType:{upgradeType.ClassName}");

                    List<string> listMissingGenericArgument = new();
                    foreach (var genericArgument in upgradeType.ListGenericArgument) {
                        if (fullNamePart.ListGenericArgument.Contains(genericArgument)) {
                            // skip
                        } else {
                            listMissingGenericArgument.Add(genericArgument);
                        }
                    }
                    var missingGenericArgument = GenericArgumentToString(listMissingGenericArgument);

                    sb.AppendLine($"    public {upgradeType.ClassName} As{upgradeType.MethodName}{missingGenericArgument}() {{");

                    sb.AppendLine($"        return this.Mode switch {{");
                    foreach (var fullNamePartPart in fullNamePart.Parts) {
                        sb.Append($"            {fullNamePart.ModeTypeName}.{fullNamePartPart.EnumValueName} => new {upgradeType.ClassName}({upgradeType.ModeTypeName}.{fullNamePartPart.EnumValueName}, ");
                        foreach (var upgradeTypePart in upgradeType.Parts.ToListIndex()) {
                            if (upgradeTypePart.Item.EnumValueName == fullNamePartPart.EnumValueName) {
                                sb.Append($"this.{fullNamePartPart.PartName}");
                            } else {
                                sb.Append("default");
                            }
                            if (!upgradeTypePart.isLast) {
                                sb.Append(", ");
                            }
                        }
                        sb.AppendLine("),");
                    }
                    sb.AppendLine($"            _ => throw new UninitializedException()");
                    sb.AppendLine($"        }};");
                    sb.AppendLine($"    }}");
                    /*
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
                    */
                }
                sb.AppendLine("}");
            }
        }

        // generated 4 Construction

        foreach (var fullNamePart in listFullNamePart) {
            StringBuilder sb = getFile($"Datum.{fullNamePart.FileName}.Construction.cs");

            sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
            sb.AppendLine("");
            sb.AppendLine("// generated 4");
            sb.AppendLine("");
            sb.AppendLine("public static partial class Datum {");

            if (fullNamePart.Parts.Length == 1) {
                sb.AppendLine("// generated 4 Construction");
                sb.AppendLine("");
                var part = fullNamePart.Parts[0];
                sb.AppendLine("    public static ", fullNamePart.ClassName, " As", fullNamePart.ClassName, "(");
                foreach (var li in fullNamePart.Parameters.ToListIndex()) {
                    if (li.Item.ParameterMode == ParameterMode.Value) {
                        sb.AppendLine("        this ", li.Item.ToString(), li.isLast ? "" : ",");
                    } else {
                        sb.AppendLine("        ", li.Item.ToString(), li.isLast ? "" : ",");
                    }
                }
                sb.AppendLine("    ) {");
                sb.Append("        return new ", fullNamePart.ClassName, "(");
                foreach (var li in fullNamePart.Parameters.ToListIndex()) {
                    sb.Append(li.Item.Name, li.isLast ? "" : ", ");
                }
                sb.AppendLine(");");
                sb.AppendLine("    }");
            } else {
                foreach (var partIndex in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("");
                    sb.AppendLine("    // generated 4 Construction");
                    sb.AppendLine("    public static ", fullNamePart.ClassName, " As", fullNamePart.ClassName, "(");
                    sb.AppendLine("        this ", partIndex.Item.ClassName, " ", partIndex.Item.ArgName);
                    sb.AppendLine("    ) {");
                    sb.AppendLine("        return new ", fullNamePart.ClassName, "(");
                    sb.AppendLine("           ", fullNamePart.ModeTypeName, ".", partIndex.Item.EnumValueName, ",");
                    foreach (var partIndexParameter in fullNamePart.Parts.ToListIndex()) {
                        if (partIndex.index == partIndexParameter.index) {
                            sb.AppendLine("           ", partIndexParameter.Item.ArgName, partIndexParameter.isLast ? "" : ",");
                        } else {
                            sb.AppendLine("           default", partIndexParameter.isLast ? "" : ",");
                        }
                    }
                    sb.AppendLine("        );");
                    sb.AppendLine("    }");
                }
            }

            if (iTypeValueError == (fullNamePart.iType & iTypeValueError)) {
                sb.AppendLine("");
                sb.AppendLine("    // generated 4 TryCatch");
                var genericArguments = string.Join(", ", fullNamePart.ListGenericArgument);
                sb.AppendLine("    public static ", fullNamePart.ClassName, " TryCatch<", genericArguments, ">(this Func<", fullNamePart.ClassName, "> fn) {");
                sb.AppendLine("        try {");
                sb.AppendLine("            return fn();");
                sb.AppendLine("        } catch (Exception error) {");
                sb.AppendLine("            return ErrorDatum.CreateFromCatchedException(error).As", fullNamePart.ClassName, "();");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("");
                sb.AppendLine("    public static ", fullNamePart.ClassName, " TryCatch<", genericArguments, ", A>(this A arg, Func<A, ", fullNamePart.ClassName, "> fn) {");
                sb.AppendLine("        try {");
                sb.AppendLine("            return fn(arg);");
                sb.AppendLine("        } catch (Exception error) {");
                sb.AppendLine("            return ErrorDatum.CreateFromCatchedException(error).As", fullNamePart.ClassName, "();");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("");
                sb.AppendLine("    public static async Task<", fullNamePart.ClassName, "> TryCatch", GenericArgumentToString(fullNamePart.ListGenericArgument), "(this Task<", fullNamePart.ClassName, "> value) {");
                sb.AppendLine("        try {");
                sb.AppendLine("            return await value;");
                sb.AppendLine("        } catch (Exception error) {");
                sb.AppendLine("            return ErrorDatum.CreateFromCatchedException(error).As", fullNamePart.ClassName, "();");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            sb.AppendLine("}");
        }

        // generated 5

        foreach (var fullNamePart in listFullNamePart) {
            StringBuilder sb = getFile($"{fullNamePart.FileName}.Operator.cs");

            sb.AppendLine("namespace Brimborium.TheMeaningOfLiff;");
            sb.AppendLine("");
            sb.AppendLine("// generated 5");
            sb.AppendLine("");
            sb.AppendLine("public readonly partial record struct ", fullNamePart.ClassName, " {");

            if (fullNamePart.Parts.Length == 1) {
            } else {
                foreach (var partIndex in fullNamePart.Parts.ToListIndex()) {
                    sb.AppendLine("");
                    sb.AppendLine("    // generated 5 Operator");
                    sb.AppendLine("");
                    sb.AppendLine("     public static explicit operator ", partIndex.Item.ClassName, "(", fullNamePart.ClassName, " value) {");
                    sb.AppendLine("        return (value.Mode switch {");
                    sb.AppendLine("            ", fullNamePart.ModeTypeName, ".", partIndex.Item.EnumValueName, " => value.", partIndex.Item.PartName, ",");
                    sb.AppendLine("            _ => throw new InvalidCastException()");
                    sb.AppendLine("        });");
                    sb.AppendLine("    }");
                }
            }

            sb.AppendLine("");
            sb.AppendLine("    // generated 5 switch");
            sb.AppendLine("");
            var listOutGenericArgument = fullNamePart.ListGenericArgument.Select(a => $"O{a}").ToList();
            var csvOutGenericArgument = GenericArgumentToString(listOutGenericArgument);
            var fullNameOut = fullNamePart.GetClassNameWithGenericArgument(listOutGenericArgument);
            sb.AppendLine("/*");
            sb.AppendLine("    public static ", fullNameOut, " Switch<", csvOutGenericArgument, ">(");
            sb.AppendLine("    public static ValueFailureErrorDatum<V, F> Switch<V, F>(");
            sb.AppendLine("        this ValueFailureErrorDatum<V, F> value,");
            sb.AppendLine("        ValueFailureErrorDatum<V, F> defaultValue,");
            sb.AppendLine("        Func<ValueDatum<V>, ValueFailureErrorDatum<V, F>>? valueFunc,");
            sb.AppendLine("        Func<FailureDatum<F>, ValueFailureErrorDatum<V, F>>? failureFunc,");
            sb.AppendLine("        Func<ErrorDatum, ValueFailureErrorDatum<V, F>>? errorFunc");
            sb.AppendLine("        ) {");
            sb.AppendLine("        try {");
            sb.AppendLine("            return value.Mode switch {");
            sb.AppendLine("                ValueFailureErrorMode.Value => (valueFunc is not null) ? valueFunc(value.Value) : defaultValue,");
            sb.AppendLine("                ValueFailureErrorMode.Failure => (failureFunc is not null) ? failureFunc(value.Failure) : value,");
            sb.AppendLine("                ValueFailureErrorMode.Error => (errorFunc is not null) ? errorFunc(value.Error):value,");
            sb.AppendLine("                _ => defaultValue");
            sb.AppendLine("            };");
            sb.AppendLine("        } catch (Exception error) {");
            sb.AppendLine("            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<V, F>();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("*/");
            sb.AppendLine("");

            sb.AppendLine("}");
        }


        foreach (var kvFile in dictFile) {
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(targetPath, kvFile.Key),
                kvFile.Value.ToString());
        }
        StringBuilder getFile(string name) {
            if (dictFile.TryGetValue(name, out var sb)) {
                return sb;
            } else {
                sb = new StringBuilder();
                dictFile[name] = sb;
                return sb;
            }
        }
    }

    private static string GenericArgumentToString(List<string> listGenericArgument) {
        return listGenericArgument.Count == 0
            ? ""
            : ("<" + string.Join(", ", listGenericArgument) + ">");
    }

    public static string GetFolder([CallerFilePath] string? filePath = default) {
        return System.IO.Path.GetDirectoryName(filePath) ?? string.Empty;
    }
}
public record NamePart(int iType, Type Type, string PartName, string ArgName, string EnumValueName, string ClassName, string GenericTypeArgName, string FileName) {
    public List<Parameter> Parameters { get; } = new();
    public override string ToString() {
        return this.PartName;
    }

}

public record FullNamePart(int iType, NamePart[] Parts) {
    public string FileName { get; set; } = string.Empty;

    public string ClassName { get; set; } = string.Empty;

    public string ClassNameNoGenericArgument { get; set; } = string.Empty;

    public string GetClassNameWithGenericArgument(List<string> listGenericArgument) {
        if (listGenericArgument.Count == 0) {
            return this.ClassNameNoGenericArgument;
        } else {
            var csvGenericArgument = string.Join(", ", listGenericArgument);
            return $"{this.ClassNameNoGenericArgument}<{csvGenericArgument}>";
        }
    }

    public List<Parameter> Parameters { get; } = new();

    public List<string> ListGenericArgument { get; } = new();

    public string ArgName { get; set; } = string.Empty;

    public string ModeTypeName { get; set; } = string.Empty;

    public List<Downgrade> ListDowngrade { get; } = new();

    public List<Upgrade> ListUpgrade { get; } = new();

    private string _MethodName = string.Empty;
    public string MethodName {
        get {
            if (this._MethodName.Length > 0) { return this._MethodName; }
            var pos = this.ClassName.IndexOf('<');
            return _MethodName = (pos switch {
                < 0 => this.ClassName,
                _ => this.ClassName.Substring(0, pos)
            });
        }
    }

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

public record Upgrade(FullNamePart extractType, FullNamePart downgradeType);

public record Downgrade(FullNamePart extractType, FullNamePart upgradeType);

public enum ParameterMode { Mode, Value, AdditionalValue, CaseValue, Meaning, LogicalTimestamp, IsLogged }
public record Parameter(
    string ParameterType,
    bool Nullable,
    string Name,
    bool HasDefaultValue,
    object? DefaultValue
    ) {
    public ParameterMode ParameterMode { get; set; }
    public override string ToString() {
        var q = this.Nullable ? "?" : "";
        if (this.HasDefaultValue) {
            return $"{this.ParameterType}{q} {this.Name} = default";
        } else {
            return $"{this.ParameterType}{q} {this.Name}";
        }
    }
}