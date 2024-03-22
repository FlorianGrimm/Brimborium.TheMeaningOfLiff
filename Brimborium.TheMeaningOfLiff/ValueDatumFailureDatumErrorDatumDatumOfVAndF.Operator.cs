namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatumFailureDatumErrorDatumDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            ValueDatumFailureDatumErrorDatumMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            ValueDatumFailureDatumErrorDatumMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueDatumFailureDatumErrorDatumDatum<V, F> value) {
        return (value.Mode switch {
            ValueDatumFailureDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueDatumFailureDatumErrorDatumDatum<OV, OF> Then<OV, OF>(
        ValueDatumFailureDatumErrorDatumDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueDatumFailureDatumErrorDatumDatum<OV, OF>, ValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, ValueDatumFailureDatumErrorDatumDatum<OV, OF>, ValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcFailureDatum = default,
        Func<ErrorDatum, ValueDatumFailureDatumErrorDatumDatum<OV, OF>, ValueDatumFailureDatumErrorDatumDatum<OV, OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                ValueDatumFailureDatumErrorDatumMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueDatumFailureDatumErrorDatumMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                ValueDatumFailureDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumFailureDatumErrorDatumDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue, value, default, default, default);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Value, value, default, default);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Failure, default, value, default);

    public ValueDatumFailureDatumErrorDatumDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new ValueDatumFailureDatumErrorDatumDatum<V, F>(ValueDatumFailureDatumErrorDatumMode.Error, default, default, value);

}
