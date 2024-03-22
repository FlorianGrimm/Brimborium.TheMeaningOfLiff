namespace Brimborium.TheMeaningOfLiff;

// generated 3

public readonly partial record struct ValueDatumFailureDatumDatum<V, F>{

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum() {
        return this.Mode switch {
            ValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, this.ValueDatum, default),
            ValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, this.FailureDatum),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            ValueDatumFailureDatumMode.Value => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, this.ValueDatum, default, default),
            ValueDatumFailureDatumMode.Failure => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

// generated 3 Upgrade

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum() {
        return this.Mode switch {
            ValueDatumFailureDatumMode.Value => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, this.ValueDatum, default, default),
            ValueDatumFailureDatumMode.Failure => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, this.FailureDatum, default),
            _ => throw new UninitializedException()
        };
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumDatum<V, F>(ValueDatum<V> value) {
        return new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Value, value, default);
    }

    // generated 3 type cast

    public static implicit operator ValueDatumFailureDatumDatum<V, F>(FailureDatum<F> value) {
        return new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Failure, default, value);
    }
}
