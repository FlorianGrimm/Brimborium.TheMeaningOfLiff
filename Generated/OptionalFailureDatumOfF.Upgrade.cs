namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalFailureDatum<F>{

// generated 3 Upgrade

    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V>() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, this.OptionalDatum, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, this.FailureDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3

// generated 3 Upgrade

    public OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, this.OptionalDatum, default, default),
            OptionalFailureMode.Failure => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3

// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V>() {
        return this.Mode switch {
            OptionalFailureMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalFailureMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3

    // generated 3 type cast

    public static implicit operator OptionalFailureDatum<F>(NoDatum value) {
        return new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalFailureDatum<F>(FailureDatum<F> value) {
        return new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, value);
    }
}

    // generated 3 type cast
