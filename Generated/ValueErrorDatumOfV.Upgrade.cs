namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueErrorDatum<V>{

// generated 3 Upgrade

    public OptionalValueErrorDatum<V> AsOptionalValueErrorDatum() {
        return this.Mode switch {
            ValueErrorMode.Value => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, this.Value, default),
            ValueErrorMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<F>() {
        return this.Mode switch {
            ValueErrorMode.Value => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, this.Value, default, default),
            ValueErrorMode.Error => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<F>() {
        return this.Mode switch {
            ValueErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            ValueErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueErrorDatum<V>(ValueDatum<V> value) {
        return new ValueErrorDatum<V>(ValueErrorMode.Value, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueErrorDatum<V>(ErrorDatum value) {
        return new ValueErrorDatum<V>(ValueErrorMode.Error, default, value);
    }
}
