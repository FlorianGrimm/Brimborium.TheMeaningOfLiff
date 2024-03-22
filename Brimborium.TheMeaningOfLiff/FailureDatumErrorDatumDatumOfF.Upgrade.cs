namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct FailureDatumErrorDatumDatum<F>{

// generated 3 Upgrade

    public OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            FailureDatumErrorDatumMode.Failure => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, this.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum<V>() {
        return this.Mode switch {
            FailureDatumErrorDatumMode.Failure => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, this.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V>() {
        return this.Mode switch {
            FailureDatumErrorDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            FailureDatumErrorDatumMode.Error => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, this.ErrorDatum),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator FailureDatumErrorDatumDatum<F>(FailureDatum<F> value) {
        return new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Failure, value, default);
    }

    // generated 3 type cast

    public static implicit operator FailureDatumErrorDatumDatum<F>(ErrorDatum value) {
        return new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Error, default, value);
    }
}
