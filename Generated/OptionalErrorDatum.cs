namespace Brimborium.TheMeaningOfLiff;

public enum OptionalErrorMode { NoValue, Error }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalErrorDatum(
    OptionalErrorMode Mode,
    NoDatum Optional,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();
}
