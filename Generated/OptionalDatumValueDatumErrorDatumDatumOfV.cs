namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumValueDatumErrorDatumMode { NoValue, Value, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumValueDatumErrorDatumDatum<V>(
    OptionalDatumValueDatumErrorDatumMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        OptionalDatumValueDatumErrorDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumValueDatumErrorDatumMode.Value => this.ValueDatum.Meaning,
        OptionalDatumValueDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumValueDatumErrorDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumValueDatumErrorDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalDatumValueDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
