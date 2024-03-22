namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueFailureErrorMode { NoValue, Value, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureErrorDatum<V, F>(
    OptionalValueFailureErrorMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalValueFailureErrorMode.NoValue => this.OptionalDatum.Meaning,
        OptionalValueFailureErrorMode.Value => this.ValueDatum.Meaning,
        OptionalValueFailureErrorMode.Failure => this.FailureDatum.Meaning,
        OptionalValueFailureErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueFailureErrorMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalValueFailureErrorMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalValueFailureErrorMode.Failure => this.FailureDatum.LogicalTimestamp,
        OptionalValueFailureErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
