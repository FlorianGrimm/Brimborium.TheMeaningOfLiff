namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatum<V> {
    //
    // generated 5 with
    //
    public OptionalDatumValueDatumDatum<V> WithOptionalDatum(NoDatum value)
        => new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.NoValue, value, default);

    public ValueDatum<V> WithValueDatum(ValueDatum<V> value)
        => value;

    public ValueDatumFailureDatumDatum<V, F> WithFailureDatum<F>(FailureDatum<F> value)
        => new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Failure, default, value);

    public ValueDatumErrorDatumDatum<V> WithErrorDatum(ErrorDatum value)
        => new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Error, default, value);

}
