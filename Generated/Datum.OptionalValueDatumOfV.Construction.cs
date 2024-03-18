namespace Brimborium.TheMeaningOfLiff;

// generated 4 Construction

public static partial class Datum {
    public static OptionalValueDatum<V> AsOptionalValueDatum<V>(
        this NoDatum optional
    ) {
        return new OptionalValueDatum<V>(
           OptionalValueMode.NoValue,
           optional,
           default 
        );
    }
    public static OptionalValueDatum<V> AsOptionalValueDatum<V>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueDatum<V>(
           OptionalValueMode.Value,
           default ,
           value
        );
    }
}
