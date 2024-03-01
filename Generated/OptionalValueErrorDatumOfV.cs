namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueErrorMode { NoValue, Value, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueErrorDatum<V>(
    OptionalValueErrorMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
