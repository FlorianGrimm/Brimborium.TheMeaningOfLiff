namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureErrorDatum<F> {

    // generated 5 Operator

     public static explicit operator FailureDatum<F>(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ErrorDatum(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public FailureErrorDatum<OF> Switch<OF>(
        FailureErrorDatum<OF> defaultValue,
        Func<FailureDatum<F>, FailureErrorDatum<OF>>? funcFailure = default,
        Func<ErrorDatum, FailureErrorDatum<OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                FailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
                FailureErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsFailureErrorDatum<OF>();
        }
    }

}
