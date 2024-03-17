namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct ValueFailureDatum<V, F> {
     public static explicit operator ValueDatum<V>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatumOfF<F>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
}