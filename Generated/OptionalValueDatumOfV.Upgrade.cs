namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalValueDatum<V>{
    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<F>() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, this.Optional, default, default),
            OptionalValueMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, this.Value, default),
            _ => throw new UninitializedException()
        };
    }
    public OptionalValueErrorDatum<V> AsOptionalValueErrorDatum() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, this.Optional, default, default),
            OptionalValueMode.Value => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, this.Value, default),
            _ => throw new UninitializedException()
        };
    }
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalValueMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            _ => throw new UninitializedException()
        };
    }
}
