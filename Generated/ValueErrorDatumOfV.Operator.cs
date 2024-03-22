namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueErrorDatum<V> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueErrorDatum<OV> Then<OV>(
        ValueErrorDatum<OV> defaultValue,
        Func<ValueDatum<V>, ValueErrorDatum<OV>, ValueErrorDatum<OV>>? funcValue = default,
        Func<ErrorDatum, ValueErrorDatum<OV>, ValueErrorDatum<OV>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                ValueErrorMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                ValueErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueErrorDatum<V> WithOptional(NoDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value, default, default);

    public ValueErrorDatum<V> WithValue(ValueDatum<V> value)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, value, default);

    public ValueFailureErrorDatum<V, F> WithFailure<F>(FailureDatum<F> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value, default);

    public ValueErrorDatum<V> WithError(ErrorDatum value)
        => new ValueErrorDatum<V>(ValueErrorMode.Error, default, value);

}
