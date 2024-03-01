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

    public string? Meaning => (this.Mode) switch {
        OptionalValueMode.NoValue => this.Optional.Meaning,
        OptionalValueMode.Value => this.Value.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalValueMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalValueMode.Value => this.Value.LogicalTimestamp,
        _ => 0
    };
}
