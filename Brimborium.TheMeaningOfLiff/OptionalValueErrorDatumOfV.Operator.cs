namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueErrorDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueErrorDatum<OV> Then<OV>(
        OptionalValueErrorDatum<OV> defaultValue,
        Func<OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcValue = default,
        Func<ErrorDatum, OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalValueErrorMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalValueErrorMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                OptionalValueErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueErrorDatum<V> WithOptional(NoDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value, default, default);

    public OptionalValueErrorDatum<V> WithValue(ValueDatum<V> value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value, default);

    public OptionalValueFailureErrorDatum<V, F> WithFailure<F>(FailureDatum<F> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value, default);

    public OptionalValueErrorDatum<V> WithError(ErrorDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value);

}
