namespace Brimborium.TheMeaningOfLiff;

public enum ValueFailureMode { Value, Failure }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueFailureDatum<V, F>(
    ValueFailureMode Mode,
    ValueDatum<V> Value,
    FailureDatum<F> Failure
){
    private string GetDebuggerDisplay() => this.ToString();

    public string? Meaning => (this.Mode) switch {
        ValueFailureMode.Value => this.Value.Meaning,
        ValueFailureMode.Failure => this.Failure.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        ValueFailureMode.Value => this.Value.LogicalTimestamp,
        ValueFailureMode.Failure => this.Failure.LogicalTimestamp,
        _ => 0
    };
}
