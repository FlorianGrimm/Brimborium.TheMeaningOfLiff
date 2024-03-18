namespace Brimborium.TheMeaningOfLiff;

// generated 4 Construction

public static partial class Datum {
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this NoDatum optional
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.NoValue,
           optional,
           default ,
           default 
        );
    }
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.Value,
           default ,
           value,
           default 
        );
    }
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this ErrorDatum error
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.Error,
           default ,
           default ,
           error
        );
    }
}
