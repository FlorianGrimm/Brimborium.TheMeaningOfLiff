namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueFailureErrorDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueFailureErrorDatum<OV, OF> Then<OV, OF>(
        OptionalValueFailureErrorDatum<OV, OF> defaultValue,
        Func<OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcFailure = default,
        Func<ErrorDatum, OptionalValueFailureErrorDatum<OV, OF>, OptionalValueFailureErrorDatum<OV, OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalValueFailureErrorMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
                OptionalValueFailureErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueFailureErrorDatum<OV, OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureErrorDatum<V, F> WithOptional(NoDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.NoValue, value, default, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithValue(ValueDatum<V> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithFailure(FailureDatum<F> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Failure, default, default, value, default);

    public OptionalValueFailureErrorDatum<V, F> WithError(ErrorDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value);

}
