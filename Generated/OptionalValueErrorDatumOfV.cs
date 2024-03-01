namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueErrorMode { NoValue, Value, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueErrorDatum<V>(
    OptionalValueErrorMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => (this.Mode) switch {
        OptionalValueErrorMode.NoValue => this.Optional.Meaning,
        OptionalValueErrorMode.Value => this.Value.Meaning,
        OptionalValueErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalValueErrorMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalValueErrorMode.Value => this.Value.LogicalTimestamp,
        OptionalValueErrorMode.Error => this.Error.LogicalTimestamp,
        _ => 0
    };
}
