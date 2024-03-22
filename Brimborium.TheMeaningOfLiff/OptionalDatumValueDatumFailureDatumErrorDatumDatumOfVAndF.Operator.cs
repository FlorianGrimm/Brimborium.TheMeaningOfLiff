namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF> Then<OV, OF>(
        OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF> defaultValue,
        Func<OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcFailureDatum = default,
        Func<ErrorDatum, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value, default, default, default);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Value, default, value, default, default);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value, default);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value);

}
