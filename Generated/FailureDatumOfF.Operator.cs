namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureDatum<F> {
    //
    // generated 5 with
    //
    public OptionalFailureDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, value, default);

    public ValueFailureDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Value, value, default);

    public FailureDatum<F> WithFailureDatum(FailureDatum<F> value)
        => value;

    public FailureErrorDatum<F> WithErrorDatum(ErrorDatum value)
        => new FailureErrorDatum<F>(FailureErrorMode.Error, default, value);

    public ValueFailureDatum<V, F> WithValue<V>(V value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new ValueFailureDatum<V, F>(ValueFailureMode.Value, new ValueDatum<V>(value, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)), default);
}

// generated 5
