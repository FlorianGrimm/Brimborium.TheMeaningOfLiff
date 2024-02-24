namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct ValueErrorDatum<T> {
    public static implicit operator ValueErrorDatum<T>(ValueDatum<T> successValue) 
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Success, successValue, default);

    public static implicit operator ValueErrorDatum<T>(ErrorDatum errorValue) 
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default!, errorValue);


    public static implicit operator LogDatum(ValueErrorDatum<T> datum)
    => datum.Mode switch {
        ValueErrorDatumMode.Success => new LogDatum(DatumMode.Success, datum.ValueDatum.Meaning),
        ValueErrorDatumMode.Error => new LogDatum(DatumMode.Error, datum.ErrorDatum.Meaning),
        _ => new LogDatum(DatumMode.NoValue, string.Empty),
    };
}
