namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static ValueFailureDatum<V, F> AsValueFailureDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new ValueFailureDatum<V, F>(
           ValueFailureMode.Value,
           value,
           default 
        );
    }
    public static ValueFailureDatum<V, F> AsValueFailureDatum<V, F>(
        this FailureDatumOfF<F> failure
    ) {
        return new ValueFailureDatum<V, F>(
           ValueFailureMode.Failure,
           default ,
           failure
        );
    }
}
