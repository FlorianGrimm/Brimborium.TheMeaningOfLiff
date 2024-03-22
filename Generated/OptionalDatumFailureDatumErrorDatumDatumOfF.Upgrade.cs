namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumFailureDatumErrorDatumDatum<F>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V>() {
        return this.Mode switch {
            OptionalDatumFailureDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumFailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            OptionalDatumFailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(NoDatum value) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(FailureDatum<F> value) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumDatum<F> value) {
        return (value.Mode) switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(ErrorDatum value) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumErrorDatumDatum value) {
        return (value.Mode) switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumDatum<F> value) {
        return (value.Mode) switch {
            FailureDatumErrorDatumMode.Failure => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, value.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }
}
