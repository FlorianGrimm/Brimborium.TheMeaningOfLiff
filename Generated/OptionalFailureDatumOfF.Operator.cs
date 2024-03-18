namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct OptionalFailureDatum<F> {

    // generated 5 Operator

     public static explicit operator NoDatum(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.NoValue => value.Optional,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 Operator

     public static explicit operator FailureDatum<F>(OptionalFailureDatum<F> value) {
        return (value.Mode switch {
            OptionalFailureMode.Failure => value.Failure,
            _ => throw new InvalidCastException()
        });
    }

    // generated 5 switch

    public OptionalFailureDatum<OF> Switch<OF>(
        OptionalFailureDatum<OF> defaultValue,
        Func<OptionalFailureDatum<OF>>? funcOptional = default,
        Func<FailureDatum<F>, OptionalFailureDatum<OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                OptionalFailureMode.NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
                OptionalFailureMode.Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
