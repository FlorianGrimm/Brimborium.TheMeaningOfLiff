namespace Brimborium.TheMeaningOfLiff;

// generated 5 Operator

public readonly partial record struct ValueFailureErrorDatum<V, F> {
     public static explicit operator ValueDatum<V>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatum<F>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
