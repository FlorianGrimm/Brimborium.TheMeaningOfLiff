namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueErrorMode { 
    Uninitialized = 0,
    Value = 2,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueErrorDatum<V>(
    ValueErrorMode Mode,
    ValueDatum<V> ValueDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        ValueErrorMode.Value => this.ValueDatum.Meaning,
        ValueErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueErrorMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
