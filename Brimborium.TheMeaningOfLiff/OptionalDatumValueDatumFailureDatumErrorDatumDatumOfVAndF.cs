namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumValueDatumFailureDatumErrorDatumMode { NoValue, Value, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
    OptionalDatumValueDatumFailureDatumErrorDatumMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => this.ValueDatum.Meaning,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.Meaning,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
