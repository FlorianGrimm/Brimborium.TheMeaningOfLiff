namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalValueFailureErrorDatum<V, F>{

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(NoDatum value) {
        return new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value, default, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(ValueDatum<V> value) {
        return new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalValueDatum<V> value) {
        return (value.Mode) switch {
            OptionalValueMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalValueMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(FailureDatum<F> value) {
        return new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalFailureDatum<F> value) {
        return (value.Mode) switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(ValueFailureDatum<V, F> value) {
        return (value.Mode) switch {
            ValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            ValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode) switch {
            OptionalValueFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalValueFailureMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            OptionalValueFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(ErrorDatum value) {
        return new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalErrorDatum value) {
        return (value.Mode) switch {
            OptionalErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(ValueErrorDatum<V> value) {
        return (value.Mode) switch {
            ValueErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            ValueErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalValueErrorDatum<V> value) {
        return (value.Mode) switch {
            OptionalValueErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalValueErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            OptionalValueErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(FailureErrorDatum<F> value) {
        return (value.Mode) switch {
            FailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            FailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(OptionalFailureErrorDatum<F> value) {
        return (value.Mode) switch {
            OptionalFailureErrorMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value.Optional, default, default, default),
            OptionalFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            OptionalFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalValueFailureErrorDatum<V, F>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode) switch {
            ValueFailureErrorMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value.Value, default, default),
            ValueFailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value.Failure, default),
            ValueFailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value.Error),
            _ => throw new InvalidCastException()
        };
    }
}
