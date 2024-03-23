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

    public ValueErrorDatum<V> WithValue<V>(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new ValueErrorDatum<V>(ValueErrorMode.Value, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default);
}

// generated 5
