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

    public ValueFailureDatum<OV, OF> Switch<OV, OF>(
        ValueFailureDatum<OV, OF> defaultValue,
        Func<ValueDatum<V>, ValueFailureDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, ValueFailureDatum<OV, OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                ValueFailureMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
                ValueFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
