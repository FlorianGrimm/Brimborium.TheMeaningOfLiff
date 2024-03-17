namespace Brimborium.TheMeaningOfLiff;

public enum ValueFailureErrorMode { Value, Failure, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureErrorDatum<V, F>(
    ValueFailureErrorMode Mode,
    ValueDatum<V> Value,
    FailureDatumOfF<F> Failure,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
