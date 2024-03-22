namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueFailureMode { NoValue, Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureDatum<V, F>(
    OptionalValueFailureMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalValueFailureMode.NoValue => this.OptionalDatum.Meaning,
        OptionalValueFailureMode.Value => this.ValueDatum.Meaning,
        OptionalValueFailureMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueFailureMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalValueFailureMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalValueFailureMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
