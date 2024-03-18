namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalValueErrorDatum<V>{
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalValueErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalValueErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            OptionalValueErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
}
