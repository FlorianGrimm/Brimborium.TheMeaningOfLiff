namespace Brimborium.TheMeaningOfLiff;

// generated 5 Operator

public readonly partial record struct OptionalFailureErrorDatum<F> {
     public static explicit operator NoDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatum<F>(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
