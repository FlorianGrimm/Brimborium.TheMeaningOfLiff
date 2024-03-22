namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureDatum<F> {
    //
    // generated 5 with
    //
    public OptionalFailureDatum<F> WithOptional(NoDatum value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, value, default);

    public ValueFailureDatum<V, F> WithValue<V>(ValueDatum<V> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Value, value, default);

    public FailureDatum<F> WithFailure(FailureDatum<F> value)
        => value;

    public FailureErrorDatum<F> WithError(ErrorDatum value)
        => new FailureErrorDatum<F>(FailureErrorMode.Error, default, value);

}
