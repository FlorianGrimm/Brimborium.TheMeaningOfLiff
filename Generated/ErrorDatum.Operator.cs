namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ErrorDatum {
    //
    // generated 5 with
    //
    public OptionalErrorDatum WithOptional(NoDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.NoValue, value, default);

    public ValueErrorDatum<V> WithValue<V>(ValueDatum<V> value)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, value, default);

    public FailureErrorDatum<F> WithFailure<F>(FailureDatum<F> value)
        => new FailureErrorDatum<F>(FailureErrorMode.Failure, value, default);

    public ErrorDatum WithError(ErrorDatum value)
        => value;

}
