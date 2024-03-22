namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalDatumFailureDatumMode { NoValue, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalDatumFailureDatumDatum<F>(
    OptionalDatumFailureDatumMode Mode,
    NoDatum OptionalDatum,
    FailureDatum<F> FailureDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalDatumFailureDatumMode.NoValue => this.OptionalDatum.Meaning,
        OptionalDatumFailureDatumMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalDatumFailureDatumMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalDatumFailureDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}
