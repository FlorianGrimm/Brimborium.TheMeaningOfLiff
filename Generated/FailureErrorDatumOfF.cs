namespace Brimborium.TheMeaningOfLiff;

public enum FailureErrorMode { Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct FailureErrorDatum<F>(
    FailureErrorMode Mode,
    FailureDatum<F> Failure,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => (this.Mode) switch {
        FailureErrorMode.Failure => this.Failure.Meaning,
        FailureErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        FailureErrorMode.Failure => this.Failure.LogicalTimestamp,
        FailureErrorMode.Error => this.Error.LogicalTimestamp,
        _ => 0
    };
}
