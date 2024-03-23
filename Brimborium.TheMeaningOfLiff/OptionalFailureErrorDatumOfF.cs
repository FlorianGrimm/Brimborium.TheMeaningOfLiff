namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalFailureErrorMode { 
    Uninitialized = 0,
    NoValue = 1,
    Failure = 4,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureErrorDatum<F>(
    OptionalFailureErrorMode Mode,
    NoDatum OptionalDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalFailureErrorMode.NoValue => this.OptionalDatum.Meaning,
        OptionalFailureErrorMode.Failure => this.FailureDatum.Meaning,
        OptionalFailureErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalFailureErrorMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalFailureErrorMode.Failure => this.FailureDatum.LogicalTimestamp,
        OptionalFailureErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
