namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum FailureDatumErrorDatumMode { Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct FailureDatumErrorDatumDatum<F>(
    FailureDatumErrorDatumMode Mode,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        FailureDatumErrorDatumMode.Failure => this.FailureDatum.Meaning,
        FailureDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        FailureDatumErrorDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        FailureDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
