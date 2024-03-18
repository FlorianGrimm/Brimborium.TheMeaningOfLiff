namespace Brimborium.TheMeaningOfLiff;

// generated 5 Operator

public readonly partial record struct OptionalFailureDatum<F> {
     public static explicit operator NoDatum(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatum<F>(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
}
