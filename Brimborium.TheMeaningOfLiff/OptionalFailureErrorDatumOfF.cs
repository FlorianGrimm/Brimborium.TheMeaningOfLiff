namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalFailureErrorMode { NoValue, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureErrorDatum<F>(
    OptionalFailureErrorMode Mode,
    NoDatum Optional,
    FailureDatum<F> Failure,
    ErrorDatum Error
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        OptionalFailureErrorMode.NoValue => this.Optional.Meaning,
        OptionalFailureErrorMode.Failure => this.Failure.Meaning,
        OptionalFailureErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalFailureErrorMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalFailureErrorMode.Failure => this.Failure.LogicalTimestamp,
        OptionalFailureErrorMode.Error => this.Error.LogicalTimestamp,
        _ => default
    };

}
