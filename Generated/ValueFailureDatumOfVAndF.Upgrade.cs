namespace Brimborium.TheMeaningOfLiff;

// generated 3 Upgrade

public readonly partial record struct ValueFailureDatum<V, F>{
    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, this.Value, default),
            ValueFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, this.Failure),
            _ => throw new UninitializedException()
        };
    }
    public ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, this.Value, default, default),
            ValueFailureMode.Failure => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, this.Failure, default),
            _ => throw new UninitializedException()
        };
    }
    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            ValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            _ => throw new UninitializedException()
        };
    }
}
