namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumValueDatumErrorDatumDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumValueDatumErrorDatumDatum<V> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumErrorDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalDatumValueDatumErrorDatumDatum<V> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumErrorDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalDatumValueDatumErrorDatumDatum<V> value) {
        return (value.Mode switch {
            OptionalDatumValueDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumValueDatumErrorDatumDatum<OV> Then<OV>(
        OptionalDatumValueDatumErrorDatumDatum<OV> defaultValue,
        Func<OptionalDatumValueDatumErrorDatumDatum<OV>, OptionalDatumValueDatumErrorDatumDatum<OV>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalDatumValueDatumErrorDatumDatum<OV>, OptionalDatumValueDatumErrorDatumDatum<OV>>? funcValueDatum = default,
        Func<ErrorDatum, OptionalDatumValueDatumErrorDatumDatum<OV>, OptionalDatumValueDatumErrorDatumDatum<OV>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalDatumValueDatumErrorDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumValueDatumErrorDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.Value, defaultValue) : defaultValue,
                OptionalDatumValueDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumErrorDatumDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumErrorDatumDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, value, default, default);

    public OptionalDatumValueDatumErrorDatumDatum<V> WithValueDatum(ValueDatum<V> value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, value, default);

    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure, default, default, value, default);

    public OptionalDatumValueDatumErrorDatumDatum<V> WithErrorDatum(ErrorDatum value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Error, default, default, value);

}
