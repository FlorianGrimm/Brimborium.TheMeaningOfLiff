namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumValueDatumMode { NoValue, Value }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumValueDatumDatum<V>(
    OptionalDatumValueDatumMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumValueDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumValueDatumMode.Value => this.ValueDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumValueDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumValueDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        _ => default
    };

}
