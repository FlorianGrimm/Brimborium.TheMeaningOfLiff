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

    public string? Meaning => (this.Mode) switch {
        OptionalErrorMode.NoValue => this.Optional.Meaning,
        OptionalErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalErrorMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalErrorMode.Error => this.Error.LogicalTimestamp,
        _ => 0
    };
}
