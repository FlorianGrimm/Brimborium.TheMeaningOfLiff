namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumFailureDatumDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumFailureDatumDatum<F> value) {
        return (value.Mode switch {
            OptionalDatumFailureDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalDatumFailureDatumDatum<F> value) {
        return (value.Mode switch {
            OptionalDatumFailureDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumFailureDatumDatum<OF> Then<OF>(
        OptionalDatumFailureDatumDatum<OF> defaultValue,
        Func<OptionalDatumFailureDatumDatum<OF>, OptionalDatumFailureDatumDatum<OF>>? funcOptionalDatum = default,
        Func<FailureDatum<F>, OptionalDatumFailureDatumDatum<OF>, OptionalDatumFailureDatumDatum<OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalDatumFailureDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumFailureDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumFailureDatumDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.NoValue, value, default);

    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, value, default);

    public OptionalDatumFailureDatumDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.Failure, default, value);

    public OptionalDatumFailureDatumErrorDatumDatum<F> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, value);

}
