namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueFailureErrorDatum<V, F>{

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            ValueFailureErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.Value, default, default),
            ValueFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.Failure, default),
            ValueFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.Error),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(ValueDatum<V> value) {
        return new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(FailureDatum<F> value) {
        return new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(ValueFailureDatum<V, F> value) {
        return (value.Mode) switch {
            ValueFailureMode.Value => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value.Value, default, default),
            ValueFailureMode.Failure => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value.Failure, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(ErrorDatum value) {
        return new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(ValueErrorDatum<V> value) {
        return (value.Mode) switch {
            ValueErrorMode.Value => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value.Value, default, default),
            ValueErrorMode.Error => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueFailureErrorDatum<V, F>(FailureErrorDatum<F> value) {
        return (value.Mode) switch {
            FailureErrorMode.Failure => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value.Failure, default),
            FailureErrorMode.Error => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }
}
