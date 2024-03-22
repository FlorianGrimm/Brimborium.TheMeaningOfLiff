namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalFailureErrorDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalFailureErrorDatum<OF> Then<OF>(
        OptionalFailureErrorDatum<OF> defaultValue,
        Func<OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcOptional = default,
        Func<FailureDatum<F>, OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcFailure = default,
        Func<ErrorDatum, OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalFailureErrorMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalFailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
                OptionalFailureErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalFailureErrorDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureErrorDatum<F> WithOptional(NoDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithValue<V>(ValueDatum<V> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value, default, default);

    public OptionalFailureErrorDatum<F> WithFailure(FailureDatum<F> value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value, default);

    public OptionalFailureErrorDatum<F> WithError(ErrorDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value);

}
