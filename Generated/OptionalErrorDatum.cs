namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalErrorMode { 
    Uninitialized = 0,
    NoValue = 1,
    Error = 8
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalErrorDatum(
    OptionalErrorMode Mode,
    NoDatum OptionalDatum,
    ErrorDatum ErrorDatum
) : IDatum, IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalErrorMode.NoValue => this.OptionalDatum.Meaning,
        OptionalErrorMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalErrorMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalErrorMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
