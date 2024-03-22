namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalValueMode { NoValue, Value }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueDatum<V>(
    OptionalValueMode Mode,
    NoDatum OptionalDatum,
    ValueDatum<V> ValueDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalValueMode.NoValue => this.OptionalDatum.Meaning,
        OptionalValueMode.Value => this.ValueDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalValueMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalValueMode.Value => this.ValueDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
