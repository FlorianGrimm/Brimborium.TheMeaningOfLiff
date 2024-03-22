namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureDatum<V, F> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueFailureDatum<OV, OF> Then<OV, OF>(
        ValueFailureDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureDatum<OV, OF>, ValueFailureDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, ValueFailureDatum<OV, OF>, ValueFailureDatum<OV, OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                ValueFailureMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                ValueFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureDatum<V, F> WithOptional(NoDatum value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value, default, default);

    public ValueFailureDatum<V, F> WithValue(ValueDatum<V> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Value, value, default);

    public ValueFailureDatum<V, F> WithFailure(FailureDatum<F> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Failure, default, value);

    public ValueFailureErrorDatum<V, F> WithError(ErrorDatum value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Error, default, default, value);

}
