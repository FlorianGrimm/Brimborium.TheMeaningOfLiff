namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumValueDatumDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumValueDatumDatum<V> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalDatumValueDatumDatum<V> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumValueDatumDatum<OV> Then<OV>(
        OptionalDatumValueDatumDatum<OV> defaultValue,
        Func<OptionalDatumValueDatumDatum<OV>, OptionalDatumValueDatumDatum<OV>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalDatumValueDatumDatum<OV>, OptionalDatumValueDatumDatum<OV>>? funcValueDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalDatumValueDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumValueDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.NoValue, value, default);

    public OptionalDatumValueDatumDatum<V> WithValueDatum(ValueDatum<V> value)
        => new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.Value, default, value);

    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.Failure, default, default, value);

    public OptionalDatumValueDatumErrorDatumDatum<V> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, value);

}
