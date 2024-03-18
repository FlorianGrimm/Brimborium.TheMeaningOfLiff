namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalErrorDatum{
    public OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, this.Optional, default, default),
            OptionalErrorMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
    public OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, this.Optional, default, default),
            OptionalErrorMode.Error => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>() {
        return this.Mode switch {
            OptionalErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
}
