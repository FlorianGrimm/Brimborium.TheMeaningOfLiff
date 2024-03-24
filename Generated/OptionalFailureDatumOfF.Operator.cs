namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalFailureDatum<F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalFailureDatum<OF> Then<OF>(
        OptionalFailureDatum<OF> defaultValue,
        Func<NoDatum, OptionalFailureDatum<OF>, OptionalFailureDatum<OF>>? funcOptionalDatum = default,
        Func<FailureDatum<F>, OptionalFailureDatum<OF>, OptionalFailureDatum<OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalFailureMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(this.OptionalDatum, defaultValue) : defaultValue,
                OptionalFailureMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalFailureDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, value, default);

    public OptionalValueFailureDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value, default);

    public OptionalFailureDatum<F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, value);

    public OptionalFailureErrorDatum<F> WithErrorDatum(ErrorDatum value)
        => new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, value);

    public OptionalValueFailureDatum<V, F> WithValue<V>(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default);
}

// generated 5
