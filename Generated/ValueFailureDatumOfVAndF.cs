namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueFailureMode { 
    Uninitialized = 0,
    Value = 2,
    Failure = 4
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureDatum<V, F>(
    ValueFailureMode Mode,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        ValueFailureMode.Value => this.ValueDatum.Meaning,
        ValueFailureMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueFailureMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueFailureMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
