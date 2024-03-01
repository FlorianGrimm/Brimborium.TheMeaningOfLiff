namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct ValueErrorDatum<V> {
     public static explicit operator ValueDatum<V>(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
