namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumValueDatumDatum<V>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum<F>() {
        return this.Mode switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, this.ValueDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum() {
        return this.Mode switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, this.ValueDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<F>() {
        return this.Mode switch {
            OptionalDatumValueDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumValueDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumDatum<V>(NoDatum value) {
        return new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumValueDatumDatum<V>(ValueDatum<V> value) {
        return new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.Value, default, value);
    }
}
