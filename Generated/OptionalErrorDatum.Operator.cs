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

    // generated 5 switch

    public OptionalErrorDatum Switch(
        OptionalErrorDatum defaultValue,
        Func<OptionalErrorDatum>? funcOptional = default,
        Func<ErrorDatum, OptionalErrorDatum>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalErrorMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalErrorDatum();
        }
    }

}
