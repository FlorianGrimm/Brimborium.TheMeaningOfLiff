namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new ValueFailureErrorDatum<V, F>(
           ValueFailureErrorMode.Value,
           value,
           default ,
           default 
        );
    }
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this FailureDatumOfF<F> failure
    ) {
        return new ValueFailureErrorDatum<V, F>(
           ValueFailureErrorMode.Failure,
           default ,
           failure,
           default 
        );
    }
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this ErrorDatum error
    ) {
        return new ValueFailureErrorDatum<V, F>(
           ValueFailureErrorMode.Error,
           default ,
           default ,
           error
        );
    }
}
