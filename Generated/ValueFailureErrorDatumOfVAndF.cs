namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueFailureErrorMode { 
    Uninitialized = 0,
    Value = 2,
    Failure = 4,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureErrorDatum<V, F>(
    ValueFailureErrorMode Mode,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        ValueFailureErrorMode.Value => this.ValueDatum.Meaning,
        ValueFailureErrorMode.Failure => this.FailureDatum.Meaning,
        ValueFailureErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueFailureErrorMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueFailureErrorMode.Failure => this.FailureDatum.LogicalTimestamp,
        ValueFailureErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
