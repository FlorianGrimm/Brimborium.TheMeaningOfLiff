namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct NoDatum {
    //
    // generated 5 with
    //
    public NoDatum WithOptionalDatum(NoDatum value)
        => value;

    public OptionalValueDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalValueDatum<V>(OptionalValueMode.Value, default, value);

    public OptionalFailureDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, value);

    public OptionalErrorDatum WithErrorDatum(ErrorDatum value)
        => new OptionalErrorDatum(OptionalErrorMode.Error, default, value);

}

// generated 5
