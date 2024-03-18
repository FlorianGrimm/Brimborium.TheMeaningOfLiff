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

    // generated 5 switch

    public OptionalFailureErrorDatum<OF> Switch<OF>(
        OptionalFailureErrorDatum<OF> defaultValue,
        Func<OptionalFailureErrorDatum<OF>>? funcOptional = default,
        Func<FailureDatum<F>, OptionalFailureErrorDatum<OF>>? funcFailure = default,
        Func<ErrorDatum, OptionalFailureErrorDatum<OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalFailureErrorMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalFailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
                OptionalFailureErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalFailureErrorDatum<OF>();
        }
    }

}
