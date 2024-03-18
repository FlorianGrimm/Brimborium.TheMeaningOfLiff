namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct OptionalFailureDatum<F>{
    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V>() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, this.Optional, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, this.Failure),
            _ => throw new UninitializedException()
        };
    }
    public OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, this.Optional, default, default),
            OptionalFailureMode.Failure => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, this.Failure, default),
            _ => throw new UninitializedException()
        };
    }
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V>() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.Optional, default, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            _ => throw new UninitializedException()
        };
    }
}
