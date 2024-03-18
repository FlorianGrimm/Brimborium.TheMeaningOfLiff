namespace Brimborium.TheMeaningOfLiff;

// generated 5 Operator

public readonly partial record struct OptionalErrorDatum {
     public static explicit operator NoDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }
     public static explicit operator ErrorDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }
}
