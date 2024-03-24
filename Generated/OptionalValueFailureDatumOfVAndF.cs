namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueFailureMode { 
    Uninitialized = 0,
    NoValue = 1,
    Value = 2,
    Failure = 4
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureDatum<V, F>(
    OptionalValueFailureMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
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
