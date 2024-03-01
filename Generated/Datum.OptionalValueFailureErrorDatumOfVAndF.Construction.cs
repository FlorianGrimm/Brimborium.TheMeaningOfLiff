namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.NoValue,
           optional,
           default ,
           default ,
           default 
        );
    }
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Value,
           default ,
           value,
           default ,
           default 
        );
    }
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Failure,
           default ,
           default ,
           failure,
           default 
        );
    }
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this ErrorDatum error
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Error,
           default ,
           default ,
           default ,
           error
        );
    }
}
