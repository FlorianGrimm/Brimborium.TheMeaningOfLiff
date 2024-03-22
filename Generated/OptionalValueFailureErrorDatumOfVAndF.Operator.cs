namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueFailureErrorDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueFailureErrorDatum<OV, OF> Then<OV, OF>(
        OptionalValueFailureErrorDatum<OV, OF> defaultValue,
        Func<OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcFailureDatum = default,
        Func<ErrorDatum, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalValueFailureErrorMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueFailureErrorDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureErrorDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value, default, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value, default);

    public OptionalValueFailureErrorDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value);

}

// generated 5
