namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueMode { NoValue, Value }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueDatum<V>(
    OptionalValueMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value
){
    private string GetDebuggerDisplay() => this.ToString();
}
