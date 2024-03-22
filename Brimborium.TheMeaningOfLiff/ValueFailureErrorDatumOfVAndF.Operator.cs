namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureErrorDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueFailureErrorDatum<OV, OF> Then<OV, OF>(
        ValueFailureErrorDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcFailure = default,
        Func<ErrorDatum, ValueFailureErrorDatum<OV, OF>, ValueFailureErrorDatum<OV, OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                ValueFailureErrorMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                ValueFailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
                ValueFailureErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureErrorDatum<V, F> WithOptional(NoDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value, default, default, default);

    public ValueFailureErrorDatum<V, F> WithValue(ValueDatum<V> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value, default, default);

    public ValueFailureErrorDatum<V, F> WithFailure(FailureDatum<F> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value, default);

    public ValueFailureErrorDatum<V, F> WithError(ErrorDatum value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value);

}
