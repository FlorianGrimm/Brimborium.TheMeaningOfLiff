namespace Brimborium.TheMeaningOfLiff;

// generated 5 Operator

public readonly partial record struct OptionalValueFailureErrorDatum<V, F> {
     public static explicit operator NoDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ValueDatum<V>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatum<F>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
