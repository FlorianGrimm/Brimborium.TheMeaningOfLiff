namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalValueFailureDatum<V, F> {
     public static explicit operator NoDatum(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ValueDatum<V>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator FailureDatum<F>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }
}
