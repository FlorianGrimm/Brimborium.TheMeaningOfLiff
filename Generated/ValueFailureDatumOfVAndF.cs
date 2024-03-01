namespace Brimborium.TheMeaningOfLiff;

public enum ValueFailureMode { Value, Failure }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureDatum<V, F>(
    ValueFailureMode Mode,
    ValueDatum<V> Value,
    FailureDatum<F> Failure
){
    private string GetDebuggerDisplay() => this.ToString();
}
