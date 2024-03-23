namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueErrorDatum<V> {

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public ValueErrorDatum<OV> Then<OV>(
        ValueErrorDatum<OV> defaultValue,
        Func<ValueDatum<V>, ValueErrorDatum<OV>, ValueErrorDatum<OV>>? funcValueDatum = default,
        Func<ErrorDatum, ValueErrorDatum<OV>, ValueErrorDatum<OV>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                ValueErrorMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                ValueErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueErrorDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value, default, default);

    public ValueErrorDatum<V> WithValueDatum(ValueDatum<V> value)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, value, default);

    public ValueFailureErrorDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Failure, default, value, default);

    public ValueErrorDatum<V> WithErrorDatum(ErrorDatum value)
        => new ValueErrorDatum<V>(ValueErrorMode.Error, default, value);

    public ValueErrorDatum<V> WithValue(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default);
}

// generated 5
