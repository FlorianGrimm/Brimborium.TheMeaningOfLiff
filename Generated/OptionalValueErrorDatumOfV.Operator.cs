namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalValueErrorDatum<V> {
     public static explicit operator NoDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ValueDatum<V>(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
