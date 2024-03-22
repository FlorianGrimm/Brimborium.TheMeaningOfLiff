namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueFailureDatum<V, F>{

// generated 3 Upgrade

    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, this.ValueDatum, default),
            ValueFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, this.FailureDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3

// generated 3 Upgrade

    public ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, this.ValueDatum, default, default),
            ValueFailureMode.Failure => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.ValueDatum, default, default),
            ValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3

    // generated 3 type cast

    public static implicit operator ValueFailureDatum<V, F>(ValueDatum<V> value) {
        return new ValueFailureDatum<V, F>(ValueFailureMode.Value, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueFailureDatum<V, F>(FailureDatum<F> value) {
        return new ValueFailureDatum<V, F>(ValueFailureMode.Failure, default, value);
    }
}

    // generated 3 type cast
