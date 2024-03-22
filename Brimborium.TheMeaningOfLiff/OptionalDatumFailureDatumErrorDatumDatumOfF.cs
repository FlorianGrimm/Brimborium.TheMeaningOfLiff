namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumFailureDatumErrorDatumMode { NoValue, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumFailureDatumErrorDatumDatum<F>(
    OptionalDatumFailureDatumErrorDatumMode Mode,
    NoDatum OptionalDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumFailureDatumErrorDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.Meaning,
        OptionalDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumFailureDatumErrorDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        OptionalDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
