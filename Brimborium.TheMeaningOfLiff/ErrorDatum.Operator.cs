namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ErrorDatum {
    //
    // generated 5 with
    //
    public OptionalErrorDatum WithOptionalDatum(NoDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.NoValue, value, default);

    public ValueErrorDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, value, default);

    public FailureErrorDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new FailureErrorDatum<F>(FailureErrorMode.Failure, value, default);

    public ErrorDatum WithErrorDatum(ErrorDatum value)
        => value;

}

// generated 5
