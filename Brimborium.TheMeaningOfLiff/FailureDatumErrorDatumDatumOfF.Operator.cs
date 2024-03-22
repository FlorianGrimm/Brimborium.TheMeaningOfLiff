namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureDatumErrorDatumDatum<F> {

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(FailureDatumErrorDatumDatum<F> value) {
        return (value.Mode switch {
            FailureDatumErrorDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(FailureDatumErrorDatumDatum<F> value) {
        return (value.Mode switch {
            FailureDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public FailureDatumErrorDatumDatum<OF> Then<OF>(
        FailureDatumErrorDatumDatum<OF> defaultValue,
        Func<FailureDatum<F>, FailureDatumErrorDatumDatum<OF>, FailureDatumErrorDatumDatum<OF>>? funcFailureDatum = default,
        Func<ErrorDatum, FailureDatumErrorDatumDatum<OF>, FailureDatumErrorDatumDatum<OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                FailureDatumErrorDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                FailureDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsFailureDatumErrorDatumDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumFailureDatumErrorDatumDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, value, default, default);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, value, default, default);

    public FailureDatumErrorDatumDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Failure, value, default);

    public FailureDatumErrorDatumDatum<F> WithErrorDatum(ErrorDatum value)
        => new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Error, default, value);

}
