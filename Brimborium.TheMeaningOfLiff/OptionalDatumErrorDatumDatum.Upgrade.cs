namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumErrorDatumDatum{

// generated 3 Upgrade

    public OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum<V>() {
        return this.Mode switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum<F>() {
        return this.Mode switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>() {
        return this.Mode switch {
            OptionalDatumErrorDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumErrorDatumDatum(NoDatum value) {
        return new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumErrorDatumDatum(ErrorDatum value) {
        return new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.Error, default, value);
    }
}
