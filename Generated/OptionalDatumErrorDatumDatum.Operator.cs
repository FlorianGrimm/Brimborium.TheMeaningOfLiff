namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalDatumErrorDatumDatum {

    // generated 5 Operator

    public static explicit operator NoDatum(OptionalDatumErrorDatumDatum value) {
        return (value.Mode switch {
            OptionalDatumErrorDatumMode.NoValue => value.OptionalDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

    public static explicit operator ErrorDatum(OptionalDatumErrorDatumDatum value) {
        return (value.Mode switch {
            OptionalDatumErrorDatumMode.Error => value.ErrorDatum,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Then

    public OptionalDatumErrorDatumDatum Then(
        OptionalDatumErrorDatumDatum defaultValue,
        Func<OptionalDatumErrorDatumDatum, OptionalDatumErrorDatumDatum>? funcOptionalDatum = default,
        Func<ErrorDatum, OptionalDatumErrorDatumDatum, OptionalDatumErrorDatumDatum>? funcErrorDatum = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalDatumErrorDatumMode.NoValue => (funcOptionalDatum is not null) ? funcOptionalDatum(defaultValue) : defaultValue,
                OptionalDatumErrorDatumMode.Error => (funcErrorDatum is not null) ? funcErrorDatum(this.Error, defaultValue) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumErrorDatumDatum();
        }
    }

    //
    // generated 5 with
    //
    public OptionalDatumErrorDatumDatum WithOptionalDatum(NoDatum value)
        => new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.NoValue, value, default);

    public OptionalDatumValueDatumErrorDatumDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalDatumValueDatumErrorDatumDatum<V>(OptionalDatumValueDatumErrorDatumMode.Value, default, value, default);

    public OptionalDatumFailureDatumErrorDatumDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalDatumFailureDatumErrorDatumDatum<F>(OptionalDatumFailureDatumErrorDatumMode.Failure, default, value, default);

    public OptionalDatumErrorDatumDatum WithErrorDatum(ErrorDatum value)
        => new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.Error, default, value);

}
