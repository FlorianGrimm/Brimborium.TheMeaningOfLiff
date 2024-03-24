namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueDatum<OV> Then<OV>(
        OptionalValueDatum<OV> defaultValue,
        Func<NoDatum, OptionalValueDatum<OV>, OptionalValueDatum<OV>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalValueDatum<OV>, OptionalValueDatum<OV>>? funcValueDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(this.OptionalDatum, defaultValue) : defaultValue,
                OptionalValueMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalValueDatum<V>(OptionalValueMode.NoValue, value, default);

    public OptionalValueDatum<V> WithValueDatum(ValueDatum<V> value)
        => new OptionalValueDatum<V>(OptionalValueMode.Value, default, value);

    public OptionalValueFailureDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value);

    public OptionalValueErrorDatum<V> WithErrorDatum(ErrorDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value);

    public OptionalValueDatum<V> WithValue(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new OptionalValueDatum<V>(OptionalValueMode.Value, default, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)));
}

// generated 5
