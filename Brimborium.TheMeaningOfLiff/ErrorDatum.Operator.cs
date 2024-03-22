namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ErrorDatum {
    //
    // generated 5 with
    //
    public OptionalDatumErrorDatumDatum WithOptionalDatum(NoDatum value)
        => new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.NoValue, value, default);

    public ValueDatumErrorDatumDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new ValueDatumErrorDatumDatum<V>(ValueDatumErrorDatumMode.Value, value, default);

    public FailureDatumErrorDatumDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new FailureDatumErrorDatumDatum<F>(FailureDatumErrorDatumMode.Failure, value, default);

    public ErrorDatum WithErrorDatum(ErrorDatum value)
        => value;

}
