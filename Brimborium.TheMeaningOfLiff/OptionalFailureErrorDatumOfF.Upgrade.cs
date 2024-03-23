namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalFailureErrorDatum<F>{

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V>() {
        return this.Mode switch {
            OptionalFailureErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.FailureDatum, default),
            OptionalFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(NoDatum value) {
        return new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(FailureDatum<F> value) {
        return new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(OptionalFailureDatum<F> value) {
        return (value.Mode) switch {
            OptionalFailureMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value.OptionalDatum, default, default),
            OptionalFailureMode.Failure => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(ErrorDatum value) {
        return new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(OptionalErrorDatum value) {
        return (value.Mode) switch {
            OptionalErrorMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value.OptionalDatum, default, default),
            OptionalErrorMode.Error => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureErrorDatum<F>(FailureErrorDatum<F> value) {
        return (value.Mode) switch {
            FailureErrorMode.Failure => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value.FailureDatum, default),
            FailureErrorMode.Error => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }
}

    // generated 3 type cast
