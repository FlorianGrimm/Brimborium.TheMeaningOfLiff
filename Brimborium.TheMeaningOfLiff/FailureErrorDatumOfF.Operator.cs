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

    // generated 5 Then

    public FailureErrorDatum<OF> Then<OF>(
        FailureErrorDatum<OF> defaultValue,
        Func<FailureDatum<F>, FailureErrorDatum<OF>, FailureErrorDatum<OF>>? funcFailure = default,
        Func<ErrorDatum, FailureErrorDatum<OF>, FailureErrorDatum<OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                FailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure, defaultValue) : defaultValue,
                FailureErrorMode.Error => (funcError is not null) ? funcError(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsFailureErrorDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureErrorDatum<F> WithOptional(NoDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value, default, default);

    public ValueFailureErrorDatum<V, F> WithValue<V>(ValueDatum<V> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value, default, default);

    public FailureErrorDatum<F> WithFailure(FailureDatum<F> value)
        => new FailureErrorDatum<F>(FailureErrorMode.Failure, value, default);

    public FailureErrorDatum<F> WithError(ErrorDatum value)
        => new FailureErrorDatum<F>(FailureErrorMode.Error, default, value);

}
