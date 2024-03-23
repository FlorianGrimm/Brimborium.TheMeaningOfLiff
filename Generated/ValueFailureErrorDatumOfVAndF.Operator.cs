namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureErrorDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueFailureErrorDatum<OV, OF> Then<OV, OF>(
        ValueFailureErrorDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcFailureDatum = default,
        Func<ErrorDatum, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                ValueFailureErrorMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueFailureErrorMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                ValueFailureErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureErrorDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value, default, default, default);

    public ValueFailureErrorDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value, default, default);

    public ValueFailureErrorDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value, default);

    public ValueFailureErrorDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value);

    public ValueFailureErrorDatum<V, F> WithValue(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default, default);
}

// generated 5
