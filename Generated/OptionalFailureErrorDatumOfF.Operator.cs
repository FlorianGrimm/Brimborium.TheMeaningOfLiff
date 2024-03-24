namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalFailureErrorDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalFailureErrorDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureErrorMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalFailureErrorDatum<OF> Then<OF>(
        OptionalFailureErrorDatum<OF> defaultValue,
        Func<NoDatum, OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcOptionalDatum = default,
        Func<FailureDatum<F>, OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcFailureDatum = default,
        Func<ErrorDatum, OptionalFailureErrorDatum<OF>, OptionalFailureErrorDatum<OF>>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalFailureErrorMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(this.OptionalDatum, defaultValue) : defaultValue,
                OptionalFailureErrorMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
                OptionalFailureErrorMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.ErrorDatum, defaultValue) : this.ErrorDatum,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalFailureErrorDatum<OF>();
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureErrorDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, value, default, default);

    public OptionalValueFailureErrorDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, value, default, default);

    public OptionalFailureErrorDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, value, default);

    public OptionalFailureErrorDatum<F> WithErrorDatum(ErrorDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value);

    public OptionalValueFailureErrorDatum<V, F> WithValue<V>(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Value, default, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default, default);
}

// generated 5
