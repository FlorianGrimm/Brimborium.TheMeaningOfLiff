namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueErrorDatum<V> {

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ErrorDatum(ValueErrorDatum<V> value) {
        return (value.Mode switch {
            ValueErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public ValueErrorDatum<OV> Switch<OV>(
        ValueErrorDatum<OV> defaultValue,
        Func<ValueDatum<V>, ValueErrorDatum<OV>>? funcValue = default,
        Func<ErrorDatum, ValueErrorDatum<OV>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                ValueErrorMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
                ValueErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<OV>();
        }
    }

}
