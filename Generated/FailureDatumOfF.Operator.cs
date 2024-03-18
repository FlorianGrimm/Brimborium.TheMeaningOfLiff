namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureDatum<F> {

    // generated 5 switch

    public FailureDatum<OF> Switch<OF>(
        FailureDatum<OF> defaultValue,
        Func<FailureDatum<F>, FailureDatum<OF>>? funcFailure = default
        ) {
        {
            return (this.Mode) switch {
                .Failure => (funcFailure is not null) ? funcFailure(this.Failure) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
