namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueFailureMode { Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureDatum<V, F>(
    ValueFailureMode Mode,
    ValueDatum<V> Value,
    FailureDatum<F> Failure
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Brimborium.TheMeaningOfLiff.Meaning? Meaning => this.Mode switch {
        ValueFailureMode.Value => this.Value.Meaning,
        ValueFailureMode.Failure => this.Failure.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueFailureMode.Value => this.Value.LogicalTimestamp,
        ValueFailureMode.Failure => this.Failure.LogicalTimestamp,
        _ => default
    };

}
