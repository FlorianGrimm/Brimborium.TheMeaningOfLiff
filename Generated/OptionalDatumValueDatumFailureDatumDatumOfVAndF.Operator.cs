namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumValueDatumFailureDatumDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalDatumValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalDatumValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumFailureDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumValueDatumFailureDatumDatum<OV, OF> Then<OV, OF>(
        OptionalDatumValueDatumFailureDatumDatum<OV, OF> defaultValue,
        Func<OptionalDatumValueDatumFailureDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumDatum<OV, OF>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalDatumValueDatumFailureDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, OptionalDatumValueDatumFailureDatumDatum<OV, OF>, OptionalDatumValueDatumFailureDatumDatum<OV, OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalDatumValueDatumFailureDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumValueDatumFailureDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.Value, defaultValue) : defaultValue,
                OptionalDatumValueDatumFailureDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.Failure, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, value, default, default);

    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Value, default, value, default);

    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, value);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Error, default, default, default, value);

}
