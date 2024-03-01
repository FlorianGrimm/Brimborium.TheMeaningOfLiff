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
}
