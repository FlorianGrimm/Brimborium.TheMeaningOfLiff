namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueDatumFailureDatumErrorDatumDatum<V, F>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            ValueDatumFailureDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            ValueDatumFailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            ValueDatumFailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatum<V> value) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(FailureDatum<F> value) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode) switch {
            ValueDatumFailureDatumMode.Value => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, value.ValueDatum, default, default),
            ValueDatumFailureDatumMode.Failure => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, value.FailureDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(ErrorDatum value) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumErrorDatumDatum<V> value) {
        return (value.Mode) switch {
            ValueDatumErrorDatumMode.Value => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, value.ValueDatum, default, default),
            ValueDatumErrorDatumMode.Error => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumErrorDatumDatum<V, F>(FailureDatumErrorDatumDatum<F> value) {
        return (value.Mode) switch {
            FailureDatumErrorDatumMode.Failure => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, value.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }
}
