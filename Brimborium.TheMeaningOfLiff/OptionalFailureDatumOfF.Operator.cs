namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalFailureDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalFailureDatum<OF> Then<OF>(
        OptionalFailureDatum<OF> defaultValue,
        Func<OptionalFailureDatum<OF>, OptionalFailureDatum<OF>>? funcOptional = default,
        Func<FailureDatum<F>, OptionalFailureDatum<OF>, OptionalFailureDatum<OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                OptionalFailureMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureDatum<F> WithOptional(NoDatum value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, value, default);

    public OptionalValueFailureDatum<V, F> WithValue<V>(ValueDatum<V> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value, default);

    public OptionalFailureDatum<F> WithFailure(FailureDatum<F> value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, value);

    public OptionalFailureErrorDatum<F> WithError(ErrorDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value);

}
