namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct FailureDatum<F> {
    //
    // generated 5 with
    //
    public OptionalDatumFailureDatumDatum<F> WithOptionalDatum(NoDatum value)
        => new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.NoValue, value, default);

    public ValueDatumFailureDatumDatum<V, F> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueDatumFailureDatumDatum<V, F>(ValueDatumFailureDatumMode.Value, value, default);

    public FailureDatum<F> WithFailureDatum(FailureDatum<F> value)
        => value;

    public FailureDatumErrorDatumDatum<F> WithErrorDatum(ErrorDatum value)
        => new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Error, default, value);

}
