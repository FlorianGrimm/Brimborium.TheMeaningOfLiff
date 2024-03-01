namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueFailureMode { NoValue, Value, Failure }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureDatum<V, F>(
    OptionalValueFailureMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    FailureDatum<F> Failure
){
    private string GetDebuggerDisplay() => this.ToString();
}
