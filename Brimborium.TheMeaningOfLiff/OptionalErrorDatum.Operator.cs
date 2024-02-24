namespace Brimborium.TheMeaningOfLiff;
public readonly partial record struct OptionalErrorDatum {
    //public static implicit operator bool(OptionalErrorDatum that)
    //    => that.Mode == OptionalErrorDatumMode.Error;

    //public static implicit operator OptionalErrorDatum(Exception exception)
    //    => new OptionalErrorDatum(OptionalErrorDatumMode.Error, default, new ErrorDatum(exception, default, default, 0, false));

    public static implicit operator OptionalErrorDatum(NoDatum datum)
        => new OptionalErrorDatum(OptionalErrorDatumMode.NoValue, datum,default);

    public static implicit operator OptionalErrorDatum(ErrorDatum datum)
        => new OptionalErrorDatum(OptionalErrorDatumMode.Error, default, datum);
}
