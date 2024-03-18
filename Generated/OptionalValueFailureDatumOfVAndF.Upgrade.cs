namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalValueFailureDatum<V, F>{
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            OptionalValueFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            OptionalValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            _ => throw new UninitializedException()
        };
    }
}
