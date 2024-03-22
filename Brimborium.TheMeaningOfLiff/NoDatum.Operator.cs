namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct NoDatum {
    //
    // generated 5 with
    //
    public NoDatum WithOptionalDatum(NoDatum value)
        => value;

    public OptionalDatumValueDatumDatum<V> WithValueDatum<V>(ValueDatum<V> value)
        => new OptionalDatumValueDatumDatum<V>(OptionalDatumValueDatumMode.Value, default, value);

    public OptionalDatumFailureDatumDatum<F> WithFailureDatum<F>(FailureDatum<F> value)
        => new OptionalDatumFailureDatumDatum<F>(OptionalDatumFailureDatumMode.Failure, default, value);

    public OptionalDatumErrorDatumDatum WithErrorDatum(ErrorDatum value)
        => new OptionalDatumErrorDatumDatum(OptionalDatumErrorDatumMode.Error, default, value);

}
