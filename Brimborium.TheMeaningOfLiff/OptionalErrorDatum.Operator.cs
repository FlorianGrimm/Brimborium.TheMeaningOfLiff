namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalErrorDatum {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalErrorDatum value) {
        return (value.Mode switch {
            OptionalErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalErrorDatum Then(
        OptionalErrorDatum defaultValue,
        Func<OptionalErrorDatum, OptionalErrorDatum>? funcOptionalDatum = default,
        Func<ErrorDatum, OptionalErrorDatum, OptionalErrorDatum>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalErrorMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalErrorDatum();
        }
    }

    //
    // generated 5 with
    //
    public OptionalErrorDatum WithOptionalDatum(NoDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.NoValue, value, default);

    public OptionalValueErrorDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorMode.Value, default, value, default);

    public OptionalFailureErrorDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value, default);

    public OptionalErrorDatum WithErrorDatum(ErrorDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.Error, default, value);

}

// generated 5
