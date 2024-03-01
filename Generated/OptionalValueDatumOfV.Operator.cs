namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalValueDatum<V> {
     public static explicit operator NoDatum(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ValueDatum<V>(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
}
