namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatum<V> {
    //
    // generated 5 with
    //
    public OptionalValueDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalValueDatum<V>(OptionalValueMode.NoValue, value, default);

    public ValueDatum<V> WithValueDatum(ValueDatum<V> value)
        => value;

    public ValueFailureDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Failure, default, value);

    public ValueErrorDatum<V> WithErrorDatum(ErrorDatum value)
        => new ValueErrorDatum<V>(ValueErrorMode.Error, default, value);

}

// generated 5
