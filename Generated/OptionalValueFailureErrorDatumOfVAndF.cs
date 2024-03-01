namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueFailureErrorMode { NoValue, Value, Failure, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalValueFailureErrorDatum<V, F>(
    OptionalValueFailureErrorMode Mode,
    NoDatum Optional,
    ValueDatum<V> Value,
    FailureDatum<F> Failure,
    ErrorDatum Error
){
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => (this.Mode) switch {
        OptionalValueFailureErrorMode.NoValue => this.Optional.Meaning,
        OptionalValueFailureErrorMode.Value => this.Value.Meaning,
        OptionalValueFailureErrorMode.Failure => this.Failure.Meaning,
        OptionalValueFailureErrorMode.Error => this.Error.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalValueFailureErrorMode.NoValue => this.Optional.LogicalTimestamp,
        OptionalValueFailureErrorMode.Value => this.Value.LogicalTimestamp,
        OptionalValueFailureErrorMode.Failure => this.Failure.LogicalTimestamp,
        OptionalValueFailureErrorMode.Error => this.Error.LogicalTimestamp,
        _ => 0
    };
}
