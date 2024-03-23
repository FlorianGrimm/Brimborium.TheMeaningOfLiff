namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct FailureErrorDatum<F>{

// generated 3 Upgrade

    public OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum() {
        return this.Mode switch {
            FailureErrorMode.Failure => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, this.FailureDatum, default),
            FailureErrorMode.Error => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }


// generated 3 Upgrade

    public ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V>() {
        return this.Mode switch {
            FailureErrorMode.Failure => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, this.FailureDatum, default),
            FailureErrorMode.Error => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }


// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V>() {
        return this.Mode switch {
            FailureErrorMode.Failure => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, this.FailureDatum, default),
            FailureErrorMode.Error => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }


    // generated 3 type cast

    public static implicit operator FailureErrorDatum<F>(FailureDatum<F> value) {
        return new FailureErrorDatum<F>(FailureErrorMode.Failure, value, default);
    }

    // generated 3 type cast

    public static implicit operator FailureErrorDatum<F>(ErrorDatum value) {
        return new FailureErrorDatum<F>(FailureErrorMode.Error, default, value);
    }
}

// generated 3
