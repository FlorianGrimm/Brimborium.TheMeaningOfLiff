namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueFailureErrorMode { Value, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureErrorDatum<V, F>(
    ValueFailureErrorMode Mode,
    ValueDatum<V> Value,
    FailureDatum<F> Failure,
    ErrorDatum Error
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        ValueFailureErrorMode.Value => this.Value.Meaning,
        ValueFailureErrorMode.Failure => this.Failure.Meaning,
        ValueFailureErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueFailureErrorMode.Value => this.Value.LogicalTimestamp,
        ValueFailureErrorMode.Failure => this.Failure.LogicalTimestamp,
        ValueFailureErrorMode.Error => this.Error.LogicalTimestamp,
        _ => default
    };

}
