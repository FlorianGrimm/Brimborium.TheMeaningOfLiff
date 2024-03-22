namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueDatumErrorDatumDatum<V>{

// generated 3 Upgrade

    public OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum() {
        return this.Mode switch {
            ValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, this.ValueDatum, default),
            ValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum<F>() {
        return this.Mode switch {
            ValueDatumErrorDatumMode.Value => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, this.ValueDatum, default, default),
            ValueDatumErrorDatumMode.Error => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<F>() {
        return this.Mode switch {
            ValueDatumErrorDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            ValueDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueDatumErrorDatumDatum<V>(ValueDatum<V> value) {
        return new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Value, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueDatumErrorDatumDatum<V>(ErrorDatum value) {
        return new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Error, default, value);
    }
}
