namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueFailureMode { NoValue, Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureDatum<V, F>(
    OptionalValueFailureMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    FailureDatum<F> Failure
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Brimborium.TheMeaningOfLiff.Meaning? Meaning => this.Mode switch {
        OptionalValueFailureMode.NoValue => this.Optional.Meaning,
        OptionalValueFailureMode.Value => this.Value.Meaning,
        OptionalValueFailureMode.Failure => this.Failure.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueFailureMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalValueFailureMode.Value => this.Value.LogicalTimestamp,
        OptionalValueFailureMode.Failure => this.Failure.LogicalTimestamp,
        _ => default
    };

}
