namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueErrorMode { NoValue, Value, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueErrorDatum<V>(
    OptionalValueErrorMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    ErrorDatum Error
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Brimborium.TheMeaningOfLiff.Meaning? Meaning => this.Mode switch {
        OptionalValueErrorMode.NoValue => this.Optional.Meaning,
        OptionalValueErrorMode.Value => this.Value.Meaning,
        OptionalValueErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueErrorMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalValueErrorMode.Value => this.Value.LogicalTimestamp,
        OptionalValueErrorMode.Error => this.Error.LogicalTimestamp,
        _ => default
    };

}
