namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalValueDatum<V>{

// generated 3 Upgrade

    public OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<F>() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, this.OptionalDatum, default, default),
            OptionalValueMode.Value => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, this.ValueDatum, default),
            _ => throw new UninitializedException()
        };
    }


// generated 3 Upgrade

    public OptionalValueErrorDatum<V> AsOptionalValueErrorDatum() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, this.OptionalDatum, default, default),
            OptionalValueMode.Value => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, this.ValueDatum, default),
            _ => throw new UninitializedException()
        };
    }


// generated 3 Upgrade

    public OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<F>() {
        return this.Mode switch {
            OptionalValueMode.NoValue => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalValueMode.Value => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, this.ValueDatum, default, default),
            _ => throw new UninitializedException()
        };
    }


    // generated 3 type cast

    public static implicit operator OptionalValueDatum<V>(NoDatum value) {
        return new OptionalValueDatum<V>(OptionalValueMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalValueDatum<V>(ValueDatum<V> value) {
        return new OptionalValueDatum<V>(OptionalValueMode.Value, default, value);
    }
}

// generated 3
