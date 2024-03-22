namespace Brimborium.TheMeaningOfLiff;

// generated 1 type

public enum OptionalFailureMode { NoValue, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureDatum<F>(
    OptionalFailureMode Mode,
    NoDatum Optional,
    FailureDatum<F> Failure
) : IWithMeaning, ILogicalTimestamp {
    private string GetDebuggerDisplay() => this.ToString();

    public Brimborium.TheMeaningOfLiff.Meaning? Meaning => this.Mode switch {
        OptionalFailureMode.NoValue => this.Optional.Meaning,
        OptionalFailureMode.Failure => this.Failure.Meaning,
        _ => default
    };

    public long LogicalTimestamp => this.Mode switch {
        OptionalFailureMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalFailureMode.Failure => this.Failure.LogicalTimestamp,
        _ => default
    };

}
