namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum ValueDatumErrorDatumMode { Value, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueDatumErrorDatumDatum<V>(
    ValueDatumErrorDatumMode Mode,
    ValueDatum<V> ValueDatum,
    ErrorDatum ErrorDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => this.Mode switch {
        ValueDatumErrorDatumMode.Value => this.ValueDatum.Meaning,
        ValueDatumErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        ValueDatumErrorDatumMode.Value => this.ValueDatum.LogicalTimestamp,
        ValueDatumErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => default
    };

}
