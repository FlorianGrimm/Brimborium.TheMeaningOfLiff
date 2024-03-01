namespace Brimborium.TheMeaningOfLiff;

public enum ValueErrorMode { Value, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueErrorDatum<V>(
    ValueErrorMode Mode,
    ValueDatum<V> Value,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
