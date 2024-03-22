namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumErrorDatumMode { NoValue, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumErrorDatumDatum(
    OptionalDatumErrorDatumMode Mode,
    NoDatum OptionalDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumErrorDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumErrorDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
