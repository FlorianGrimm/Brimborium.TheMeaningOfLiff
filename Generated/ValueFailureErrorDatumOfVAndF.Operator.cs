namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureErrorDatum<V, F> {

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator FailureDatum<F>(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ErrorDatum(ValueFailureErrorDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureErrorMode.Error => value.Error,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public ValueFailureErrorDatum<OV, OF> Switch<OV, OF>(
        ValueFailureErrorDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureErrorDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, ValueFailureErrorDatum<OV, OF>>? funcFailure = default,
        Func<ErrorDatum, ValueFailureErrorDatum<OV, OF>>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                ValueFailureErrorMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
                ValueFailureErrorMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
                ValueFailureErrorMode.Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<OV, OF>();
        }
    }

}
