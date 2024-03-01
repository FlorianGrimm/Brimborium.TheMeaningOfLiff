namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static ValueErrorDatum<V> AsValueErrorDatum<V>(
        this ValueDatum<V> value
    ) {
        return new ValueErrorDatum<V>(
           ValueErrorMode.Value,
           value,
           default 
        );
    }
    public static ValueErrorDatum<V> AsValueErrorDatum<V>(
        this ErrorDatum error
    ) {
        return new ValueErrorDatum<V>(
           ValueErrorMode.Error,
           default ,
           error
        );
    }
}
