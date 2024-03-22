namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>{

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(NoDatum value) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value, default, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatum<V> value) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumDatum<V> value) {
        return (value.Mode) switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(FailureDatum<F> value) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumFailureDatumDatum<F> value) {
        return (value.Mode) switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode) switch {
            ValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            ValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode) switch {
            OptionalDatumValueDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            OptionalDatumValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(ErrorDatum value) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumErrorDatumDatum value) {
        return (value.Mode) switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumErrorDatumDatum<V> value) {
        return (value.Mode) switch {
            ValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            ValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumErrorDatumDatum<V> value) {
        return (value.Mode) switch {
            OptionalDatumValueDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            OptionalDatumValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(FailureDatumErrorDatumDatum<F> value) {
        return (value.Mode) switch {
            FailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumFailureDatumErrorDatumDatum<F> value) {
        return (value.Mode) switch {
            OptionalDatumFailureDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default, default),
            OptionalDatumFailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            OptionalDatumFailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode) switch {
            ValueDatumFailureDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value.ValueDatum, default, default),
            ValueDatumFailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value.FailureDatum, default),
            ValueDatumFailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }
}
