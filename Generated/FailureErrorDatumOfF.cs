namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum FailureErrorMode { 
    Uninitialized = 0,
    Failure = 4,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct FailureErrorDatum<F>(
    FailureErrorMode Mode,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        FailureErrorMode.Failure => this.FailureDatum.Meaning,
        FailureErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        FailureErrorMode.Failure => this.FailureDatum.LogicalTimestamp,
        FailureErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
