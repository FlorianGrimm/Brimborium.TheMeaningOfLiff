namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumValueDatumErrorDatumDatum<V>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<F>() {
        return this.Mode switch {
            OptionalDatumValueDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            OptionalDatumValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(NoDatum value) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, value, default, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(ValueDatum<V> value) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumDatum<V> value) {
        return (value.Mode) switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, value.ValueDatum, default),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(ErrorDatum value) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, value);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumErrorDatumDatum value) {
        return (value.Mode) switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, value.OptionalDatum, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumDatum<V> value) {
        return (value.Mode) switch {
            ValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, value.ValueDatum, default),
            ValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, value.ErrorDatum),
            _ => throw new InvalidCastException()
        };
    }
}
