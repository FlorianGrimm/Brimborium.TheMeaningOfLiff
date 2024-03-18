namespace Brimborium.TheMeaningOfLiff;

// generated 4 Construction

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
        this FailureDatum<F> failure
    ) {
        return new ValueFailureDatum<V, F>(
           ValueFailureMode.Failure,
           default ,
           failure
        );
    }
}
