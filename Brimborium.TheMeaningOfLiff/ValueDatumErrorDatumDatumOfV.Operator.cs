namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatumErrorDatumDatum<V> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueDatumErrorDatumDatum<V> value) {
        return (value.Mode switch {
            ValueDatumErrorDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueDatumErrorDatumDatum<V> value) {
        return (value.Mode switch {
            ValueDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueDatumErrorDatumDatum<OV> Then<OV>(
        ValueDatumErrorDatumDatum<OV> defaultValue,
        Func<ValueDatum<V>, ValueDatumErrorDatumDatum<OV>, ValueDatumErrorDatumDatum<OV>>? funcValueDatum = default,
        Func<ErrorDatum, ValueDatumErrorDatumDatum<OV>, ValueDatumErrorDatumDatum<OV>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                ValueDatumErrorDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumErrorDatumDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumErrorDatumDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.NoValue, value, default, default);

    public ValueDatumErrorDatumDatum<V> WithValueDatum(ValueDatum<V> value)
        => new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Value, value, default);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, value, default);

    public ValueDatumErrorDatumDatum<V> WithErrorDatum(ErrorDatum value)
        => new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Error, default, value);

}
