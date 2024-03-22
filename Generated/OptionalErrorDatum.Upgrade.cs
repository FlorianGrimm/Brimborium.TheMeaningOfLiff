namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalErrorDatum{

// generated 3 Upgrade

    public OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, this.Optional, default, default),
            OptionalErrorMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, this.Optional, default, default),
            OptionalErrorMode.Error => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalErrorDatum(NoDatum value) {
        return new OptionalErrorDatum(OptionalErrorMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalErrorDatum(ErrorDatum value) {
        return new OptionalErrorDatum(OptionalErrorMode.Error, default, value);
    }
}
