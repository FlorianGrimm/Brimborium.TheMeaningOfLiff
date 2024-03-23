namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalValueFailureDatum<V, F>{

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum() {
        return this.Mode switch {
            OptionalValueFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.ValueDatum, default, default),
            OptionalValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(NoDatum value) {
        return new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(ValueDatum<V> value) {
        return new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(OptionalValueDatum<V> value) {
        return (value.Mode) switch {
            OptionalValueMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value.OptionalDatum, default, default),
            OptionalValueMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value.ValueDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(FailureDatum<F> value) {
        return new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(OptionalFailureDatum<F> value) {
        return (value.Mode) switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value.OptionalDatum, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value.FailureDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureDatum<V, F>(ValueFailureDatum<V, F> value) {
        return (value.Mode) switch {
            ValueFailureMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value.ValueDatum, default),
            ValueFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value.FailureDatum),
            _ => throw new InvalidCastException()
        };
    }
}

    // generated 3 type cast
