namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueErrorDatum<V> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueErrorDatum<OV> Then<OV>(
        OptionalValueErrorDatum<OV> defaultValue,
        Func<OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcValueDatum = default,
        Func<ErrorDatum, OptionalValueErrorDatum<OV>, OptionalValueErrorDatum<OV>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalValueErrorMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalValueErrorMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                OptionalValueErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<OV>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueErrorDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.NoValue, value, default, default);

    public OptionalValueErrorDatum<V> WithValueDatum(ValueDatum<V> value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value, default);

    public OptionalValueFailureErrorDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value, default);

    public OptionalValueErrorDatum<V> WithErrorDatum(ErrorDatum value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Error, default, default, value);

}

// generated 5
