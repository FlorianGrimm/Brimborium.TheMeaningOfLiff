namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalErrorDatum {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalErrorDatum Then(
        OptionalErrorDatum defaultValue,
        Func<OptionalErrorDatum, OptionalErrorDatum>? funcOptional = default,
        Func<ErrorDatum, OptionalErrorDatum, OptionalErrorDatum>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalErrorMode.NoValue => (funcOptional is not null) ? funcOptional(defaultValue) : defaultValue,
                OptionalErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalErrorDatum();
        }
    }

    //
    // generated 5 with
    //
    public OptionalErrorDatum WithOptional(NoDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.NoValue, value, default);

    public OptionalValueErrorDatum<V> WithValue<V>(ValueDatum<V> value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value, default);

    public OptionalFailureErrorDatum<F> WithFailure<F>(FailureDatum<F> value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value, default);

    public OptionalErrorDatum WithError(ErrorDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.Error, default, value);

}
