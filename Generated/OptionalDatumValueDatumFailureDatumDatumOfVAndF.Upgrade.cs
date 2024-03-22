namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumValueDatumFailureDatumDatum<V, F>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            OptionalDatumValueDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            OptionalDatumValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(NoDatum value) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(ValueDatum<V> value) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumDatum<V> value) {
        return (value.Mode) switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, value.ValueDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(FailureDatum<F> value) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumFailureDatumDatum<F> value) {
        return (value.Mode) switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, value.FailureDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode) switch {
            ValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, value.ValueDatum, default),
            ValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, value.FailureDatum),
            _ => throw new InvalidCastException()
        };
    }
}
