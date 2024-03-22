namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueFailureDatum<V, F> {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ValueDatum<V>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Value => value.ValueDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator FailureDatum<F>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Failure => value.FailureDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalValueFailureDatum<OV, OF> Then<OV, OF>(
        OptionalValueFailureDatum<OV, OF> defaultValue,
        Func<OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcOptionalDatum = default,
        Func<ValueDatum<V>, OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcValueDatum = default,
        Func<FailureDatum<F>, OptionalValueFailureDatum<OV, OF>, OptionalValueFailureDatum<OV, OF>>? funcFailureDatum = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueFailureMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalValueFailureMode.Value => (funcValueDatum is not null) ? funcValueDatum(this.ValueDatum, defaultValue) : defaultValue,
                OptionalValueFailureMode.Failure => (funcFailureDatum is not null) ? funcFailureDatum(this.FailureDatum, defaultValue) : defaultValue,
            _ => defaultValue
            };
        }
    }

    //
    // generated 5 with
    //
    public OptionalValueFailureDatum<V, F> WithOptionalDatum(NoDatum value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.NoValue, value, default, default);

    public OptionalValueFailureDatum<V, F> WithValueDatum(ValueDatum<V> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Value, default, value, default);

    public OptionalValueFailureDatum<V, F> WithFailureDatum(FailureDatum<F> value)
        => new OptionalValueFailureDatum<V, F>(OptionalValueFailureMode.Failure, default, default, value);

    public OptionalValueFailureErrorDatum<V, F> WithErrorDatum(ErrorDatum value)
        => new OptionalValueFailureErrorDatum<V, F>(OptionalValueFailureErrorMode.Error, default, default, default, value);

}

// generated 5
