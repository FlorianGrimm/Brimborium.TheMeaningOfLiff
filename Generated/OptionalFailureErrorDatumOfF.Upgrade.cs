namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalFailureErrorDatum<F>{
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V>() {
        return this.Mode switch {
            OptionalFailureErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            OptionalFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
}
