namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueFailureDatum<OV, OF> Then<OV, OF>(
        ValueFailureDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureDatum<OV, OF>, ValueFailureDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, ValueFailureDatum<OV, OF>, ValueFailureDatum<OV, OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                ValueFailureMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueFailureMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value, default, default);

    public ValueFailureDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Value, value, default);

    public ValueFailureDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Failure, default, value);

    public ValueFailureErrorDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value);

}

// generated 5
