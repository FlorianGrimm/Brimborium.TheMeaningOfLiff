namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueErrorDatum<V> {

    // generated 5 Operator

     public static explicit operator NoDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ErrorDatum(OptionalValueErrorDatum<V> value) {
        return (value.Mode switch {
            OptionalValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public OptionalValueErrorDatum<OV> Switch<OV>(
        OptionalValueErrorDatum<OV> defaultValue,
        Func<OptionalValueErrorDatum<OV>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueErrorDatum<OV>>? funcValue = default,
        Func<ErrorDatum, OptionalValueErrorDatum<OV>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                OptionalValueErrorMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalValueErrorMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
                OptionalValueErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<OV>();
        }
    }

}
