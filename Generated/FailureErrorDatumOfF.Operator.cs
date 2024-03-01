namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct FailureErrorDatum<F> {
     public static explicit operator FailureDatum<F>(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
