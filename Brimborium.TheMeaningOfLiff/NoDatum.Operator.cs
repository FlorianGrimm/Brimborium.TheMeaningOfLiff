namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct NoDatum {
    //
    // generated 5 with
    //
    public NoDatum WithOptional(NoDatum value)
        => value;

    public OptionalValueDatum<V> WithValue<V>(ValueDatum<V> value)
        => new OptionalValueDatum<V>(OptionalValueMode.Value, default, value);

    public OptionalFailureDatum<F> WithFailure<F>(FailureDatum<F> value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, value);

    public OptionalErrorDatum WithError(ErrorDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.Error, default, value);

}
