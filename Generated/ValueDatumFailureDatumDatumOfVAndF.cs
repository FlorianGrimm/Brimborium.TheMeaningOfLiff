namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueDatumFailureDatumMode { Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueDatumFailureDatumDatum<V, F>(
    ValueDatumFailureDatumMode Mode,
    ValueDatum<V> ValueDatum,
    FailureDatum<F> FailureDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        ValueDatumFailureDatumMode.Value => this.ValueDatum.Meaning,
        ValueDatumFailureDatumMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueDatumFailureDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueDatumFailureDatumMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}
