namespace Brimborium.TheMeaningOfLiff;

[Orleans.Alias(nameof(ErrorDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer(IncludePrimaryConstructorParameters = false)]
[DebuggerNonUserCode]
[method: JsonConstructor]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct FailureDatum<F>(
    [property: Orleans.Id(0)] F Value,
    [property: Orleans.Id(1)] Meaning? Meaning = default,
    [property: Orleans.Id(2)] long LogicalTimestamp = 0
    )
    : IDatum<F>
    , IWithMeaning
    , ILogicalTimestamp {

    private string GetDebuggerDisplay() {
            return $"{this.Value};{this.Meaning};{this.LogicalTimestamp}";
    }
}
