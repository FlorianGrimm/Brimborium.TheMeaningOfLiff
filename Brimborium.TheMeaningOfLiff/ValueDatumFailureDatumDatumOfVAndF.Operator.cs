namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatumFailureDatumDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode switch {
            ValueDatumFailureDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueDatumFailureDatumDatum<V, F> value) {
        return (value.Mode switch {
            ValueDatumFailureDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueDatumFailureDatumDatum<OV, OF> Then<OV, OF>(
        ValueDatumFailureDatumDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueDatumFailureDatumDatum<OV, OF>, ValueDatumFailureDatumDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, ValueDatumFailureDatumDatum<OV, OF>, ValueDatumFailureDatumDatum<OV, OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                ValueDatumFailureDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueDatumFailureDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumFailureDatumDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumFailureDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumMode.NoValue, value, default, default);

    public ValueDatumFailureDatumDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Value, value, default);

    public ValueDatumFailureDatumDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Failure, default, value);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, value);

}
