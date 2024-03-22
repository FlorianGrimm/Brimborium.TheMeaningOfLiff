namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueFailureDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueFailureDatum<OV, OF> Then<OV, OF>(
        OptionalValueFailureDatum<OV, OF> defaultValue,
        Func<OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueFailureMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalValueFailureMode.Value => (funcValue is not null) ? funcValue(this.Value, defaultValue) : defaultValue,
                OptionalValueFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureDatum<V, F> WithOptional(NoDatum value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value, default, default);

    public OptionalValueFailureDatum<V, F> WithValue(ValueDatum<V> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value, default);

    public OptionalValueFailureDatum<V, F> WithFailure(FailureDatum<F> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value);

    public OptionalValueFailureErrorDatum<V, F> WithError(ErrorDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value);

}
