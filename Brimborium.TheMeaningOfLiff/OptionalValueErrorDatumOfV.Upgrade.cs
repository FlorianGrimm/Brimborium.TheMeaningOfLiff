namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalValueErrorDatum<V>{

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalValueErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalValueErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            OptionalValueErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(NoDatum value) {
        return new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(ValueDatum<V> value) {
        return new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(OptionalValueDatum<V> value) {
        return (value.Mode) switch {
            OptionalValueMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value.Optional, default, default),
            OptionalValueMode.Value => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value.Value, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(ErrorDatum value) {
        return new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(OptionalErrorDatum value) {
        return (value.Mode) switch {
            OptionalErrorMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value.Optional, default, default),
            OptionalErrorMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueErrorDatum<V>(ValueErrorDatum<V> value) {
        return (value.Mode) switch {
            ValueErrorMode.Value => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value.Value, default),
            ValueErrorMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }
}
