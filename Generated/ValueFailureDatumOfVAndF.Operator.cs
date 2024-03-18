namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueFailureDatum<V, F> {

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator FailureDatum<F>(ValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            ValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

/*
    public static ValueFailureDatum<OV, OF> Switch<<OV, OF>>(
    public static ValueFailureErrorDatum<V, F> Switch<V, F>(
        this ValueFailureErrorDatum<V, F> value,
        ValueFailureErrorDatum<V, F> defaultValue,
        Func<ValueDatum<V>, ValueFailureErrorDatum<V, F>>? valueFunc,
        Func<FailureDatum<F>, ValueFailureErrorDatum<V, F>>? failureFunc,
        Func<ErrorDatum, ValueFailureErrorDatum<V, F>>? errorFunc
        ) {
        try {
            return value.Mode switch {
                ValueFailureErrorMode.Value => (valueFunc is not null) ? valueFunc(value.Value) : defaultValue,
                ValueFailureErrorMode.Failure => (failureFunc is not null) ? failureFunc(value.Failure) : value,
                ValueFailureErrorMode.Error => (errorFunc is not null) ? errorFunc(value.Error):value,
                _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<V, F>();
        }
    }
*/

}
