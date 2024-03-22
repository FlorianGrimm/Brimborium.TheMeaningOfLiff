namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatum<V> {
    //
    // generated 5 with
    //
    public OptionalValueDatum<V> WithOptional(NoDatum value)
        => new OptionalValueDatum<V>(OptionalValueMode.NoValue, value, default);

    public ValueDatum<V> WithValue(ValueDatum<V> value)
        => value;

    public ValueFailureDatum<V, F> WithFailure<F>(FailureDatum<F> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Failure, default, value);

    public ValueErrorDatum<V> WithError(ErrorDatum value)
        => new ValueErrorDatum<V>(ValueErrorMode.Error, default, value);

}
