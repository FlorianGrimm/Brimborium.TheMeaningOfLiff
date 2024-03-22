namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct OptionalDatumFailureDatumDatum<F>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum<V>() {
        return this.Mode switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, this.FailureDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V>() {
        return this.Mode switch {
            OptionalDatumFailureDatumMode.NoValue => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, this.OptionalDatum, default, default, default),
            OptionalDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumDatum<F>(NoDatum value) {
        return new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.NoValue, value, default);
    }

    // generated 3 type cast

    public static implicit operator OptionalDatumFailureDatumDatum<F>(FailureDatum<F> value) {
        return new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.Failure, default, value);
    }
}
