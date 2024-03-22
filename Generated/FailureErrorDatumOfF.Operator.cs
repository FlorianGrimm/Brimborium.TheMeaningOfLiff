namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureErrorDatum<F> {

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(FailureErrorDatum<F> value) {
        return (value.Mode switch {
            FailureErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public FailureErrorDatum<OF> Then<OF>(
        FailureErrorDatum<OF> defaultValue,
        Func<FailureDatum<F>, FailureErrorDatum<OF>, FailureErrorDatum<OF>>? funcFailureDatum = default,
        Func<ErrorDatum, FailureErrorDatum<OF>, FailureErrorDatum<OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                FailureErrorMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                FailureErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsFailureErrorDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureErrorDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value, default, default);

    public ValueFailureErrorDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueFailureErrorDatum<V, F>(ValueFailureErrorMode.Value, value, default, default);

    public FailureErrorDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new FailureErrorDatum<F>(FailureErrorMode.Failure, value, default);

    public FailureErrorDatum<F> WithErrorDatum(ErrorDatum value)
        => new FailureErrorDatum<F>(FailureErrorMode.Error, default, value);

}

// generated 5
