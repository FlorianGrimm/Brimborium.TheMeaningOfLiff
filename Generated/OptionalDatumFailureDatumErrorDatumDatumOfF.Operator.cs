namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumFailureDatumErrorDatumDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumFailureDatumErrorDatumDatum<F> value) {
        return (value.Mode switch {
            OptionalDatumFailureDatumErrorDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalDatumFailureDatumErrorDatumDatum<F> value) {
        return (value.Mode switch {
            OptionalDatumFailureDatumErrorDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalDatumFailureDatumErrorDatumDatum<F> value) {
        return (value.Mode switch {
            OptionalDatumFailureDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumFailureDatumErrorDatumDatum<OF> Then<OF>(
        OptionalDatumFailureDatumErrorDatumDatum<OF> defaultValue,
        Func<OptionalDatumFailureDatumErrorDatumDatum<OF>, OptionalDatumFailureDatumErrorDatumDatum<OF>>? funcOptionalDatum = default,
        Func<FailureDatum<F>, OptionalDatumFailureDatumErrorDatumDatum<OF>, OptionalDatumFailureDatumErrorDatumDatum<OF>>? funcFailureDatum = default,
        Func<ErrorDatum, OptionalDatumFailureDatumErrorDatumDatum<OF>, OptionalDatumFailureDatumErrorDatumDatum<OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalDatumFailureDatumErrorDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumFailureDatumErrorDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.Failure, defaultValue) : defaultValue,
                OptionalDatumFailureDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumFailureDatumErrorDatumDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumFailureDatumErrorDatumDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.NoValue, value, default, default);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value, default, default);

    public OptionalDatumFailureDatumErrorDatumDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, value, default);

    public OptionalDatumFailureDatumErrorDatumDatum<F> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Error, default, default, value);

}
