namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalFailureMode { 
    Uninitialized = 0,
    NoValue = 1,
    Failure = 4
 }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureDatum<F>(
    OptionalFailureMode Mode,
    NoDatum OptionalDatum,
    FailureDatum<F> FailureDatum
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Meaning? Meaning => this.Mode switch {
        OptionalFailureMode.NoValue => this.OptionalDatum.Meaning,
        OptionalFailureMode.Failure => this.FailureDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalFailureMode.NoValue => this.OptionalDatum.LogicalTimestamp,
        OptionalFailureMode.Failure => this.FailureDatum.LogicalTimestamp,
        _ => default
    };

}

// generated 1 type
