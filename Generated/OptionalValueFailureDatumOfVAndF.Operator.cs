namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalValueFailureDatum<V, F> {

    // generated 5 Operator

     public static explicit operator NoDatum(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator ValueDatum<V>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Value => value.Value,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator FailureDatum<F>(OptionalValueFailureDatum<V, F> value) {
        return (value.Mode switch {
            OptionalValueFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public OptionalValueFailureDatum<OV, OF> Switch<OV, OF>(
        OptionalValueFailureDatum<OV, OF> defaultValue,
        Func<OptionalValueFailureDatum<OV, OF>>? funcOptional = default,
        Func<ValueDatum<V>, OptionalValueFailureDatum<OV, OF>>? funcValue = default,
        Func<FailureDatum<F>, OptionalValueFailureDatum<OV, OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                OptionalValueFailureMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalValueFailureMode.Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
                OptionalValueFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
