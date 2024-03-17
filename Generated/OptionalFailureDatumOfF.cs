namespace Brimborium.TheMeaningOfLiff;

public enum OptionalFailureMode { NoValue, Failure }


[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalFailureDatum<F>(
    OptionalFailureMode Mode,
    NoDatum Optional,
    FailureDatumOfF<F> Failure
){
    private string GetDebuggerDisplay() => this.ToString();
}
