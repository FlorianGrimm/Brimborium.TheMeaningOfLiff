namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct ValueFailureErrorDatum<V, F>{
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            ValueFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            ValueFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }
}
