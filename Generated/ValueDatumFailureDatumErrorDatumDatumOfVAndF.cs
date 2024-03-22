namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueDatumFailureDatumErrorDatumMode { Value, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueDatumFailureDatumErrorDatumDatum<V, F>(
    ValueDatumFailureDatumErrorDatumMode Mode,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        ValueDatumFailureDatumErrorDatumMode.Value => this.ValueDatum.Meaning,
        ValueDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.Meaning,
        ValueDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueDatumFailureDatumErrorDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueDatumFailureDatumErrorDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        ValueDatumFailureDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
