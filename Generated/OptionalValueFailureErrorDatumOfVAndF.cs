namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueFailureErrorMode { NoValue, Value, Failure, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureErrorDatum<V, F>(
    OptionalValueFailureErrorMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    FailureDatum<F> Failure,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
