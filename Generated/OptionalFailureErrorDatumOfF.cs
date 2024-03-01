namespace Brimborium.TheMeaningOfLiff;

public enum OptionalFailureErrorMode { NoValue, Failure, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureErrorDatum<F>(
    OptionalFailureErrorMode Mode,
    NoDatum Optional,
    FailureDatum<F> Failure,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
