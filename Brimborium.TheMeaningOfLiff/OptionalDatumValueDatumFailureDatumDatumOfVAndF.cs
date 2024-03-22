namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumValueDatumFailureDatumMode { NoValue, Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumValueDatumFailureDatumDatum<V, F>(
    OptionalDatumValueDatumFailureDatumMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumValueDatumFailureDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumValueDatumFailureDatumMode.Value => this.ValueDatum.Meaning,
        OptionalDatumValueDatumFailureDatumMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumValueDatumFailureDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumValueDatumFailureDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalDatumValueDatumFailureDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}
