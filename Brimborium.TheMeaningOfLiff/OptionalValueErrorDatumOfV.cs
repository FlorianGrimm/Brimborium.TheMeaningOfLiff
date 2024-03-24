namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueErrorMode { 
    Uninitialized = 0,
    NoValue = 1,
    Value = 2,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueErrorDatum<V>(
    OptionalValueErrorMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    ErrorDatum ErrorDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalValueErrorMode.NoValue => this.OptionalDatum.Meaning,
        OptionalValueErrorMode.Value => this.ValueDatum.Meaning,
        OptionalValueErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueErrorMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalValueErrorMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalValueErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
