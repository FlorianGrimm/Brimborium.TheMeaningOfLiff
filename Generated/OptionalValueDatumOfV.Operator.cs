namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueDatum<OV> Then<OV>(
        OptionalValueDatum<OV> defaultValue,
        Func<OptionalValueDatum<OV>, OptionalValueDatum<OV>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueDatum<OV>, OptionalValueDatum<OV>>? funcValue = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalValueMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueDatum<V> WithOptional(NoDatum value)
        => new OptionalValueDatum<V>(OptionalValueMode.NoValue, value, default);

    public OptionalValueDatum<V> WithValue(ValueDatum<V> value)
        => new OptionalValueDatum<V>(OptionalValueMode.Value, default, value);

    public OptionalValueFailureDatum<V, F> WithFailure<F>(FailureDatum<F> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value);

    public OptionalValueErrorDatum<V> WithError(ErrorDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value);

}
