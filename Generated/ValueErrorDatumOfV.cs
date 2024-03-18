namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueErrorMode { Value, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueErrorDatum<V>(
    ValueErrorMode Mode,
    ValueDatum<V> Value,
    ErrorDatum Error
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        ValueErrorMode.Value => this.Value.Meaning,
        ValueErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueErrorMode.Value => this.Value.LogicalTimestamp,
        ValueErrorMode.Error => this.Error.LogicalTimestamp,
        _ => default
    };

}
