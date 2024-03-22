namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueDatum<V> {

    // generated 5 Operator

     public static explicit operator NoDatum(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(OptionalValueDatum<V> value) {
        return (value.Mode switch {
            OptionalValueMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public OptionalValueDatum<OV> Switch<OV>(
        OptionalValueDatum<OV> defaultValue,
        Func<OptionalValueDatum<OV>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueDatum<OV>>? funcValue = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalValueMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
